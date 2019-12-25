import { Component, OnInit, ViewChild, HostListener, ChangeDetectorRef } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { TipoLogradouro } from 'src/app/_models/TipoLogradouro';
import { TipologradouroService } from 'src/app/_services/tipologradouro.service';
import { Estado } from 'src/app/_models/Estado';
import { CountryService } from 'src/app/_services/country.service';
import { Country } from 'src/app/_models/Country';
import { StatesService } from 'src/app/_services/states.service';
import { JwtHelperService } from '@auth0/angular-jwt';


import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Location } from 'src/app/_interfaces/ILocation';
import { NgForm } from '@angular/forms';
import { CongregationService } from 'src/app/_services/congregation.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { PublisherService } from 'src/app/_services/publisher.service';
import { Usuario } from 'src/app/_models/Usuario';
import { Publicador } from 'src/app/_models/Publicador';
import { Router } from '@angular/router';

@Component( {
  selector: 'app-create-congregation',
  templateUrl: './create-congregation.component.html',
  styleUrls: [ './create-congregation.component.css' ]
} )
export class CreateCongregationComponent implements OnInit
{
  @ViewChild( 'createForm', {static: true} )
  createForm: NgForm;

  title = 'Congregation';
  subTitles = 'New Congregation';
  congregation: Congregacao;
  del: any;

  tipoLogradouro: TipoLogradouro[];
  selectedTipoLogradouro: number;

  estado: Estado[];
  selectedEstado: number;

  country: Country[];
  searchCountry: Country;
  selectedCountry: number;
  setPosition: any;

  lng: any;
  lat: any;
  location: Location;
  locationCountry: Location[];
  localizacao: string;

  jwtHelper = new JwtHelperService();
  user: Usuario;
  publisher: Publicador;
  auditoriaUsuario: number;

  @HostListener( 'window:beforeunload', [ '$event' ] )
  unloadNotification ( $event: any )
  {
    if ( this.createForm.dirty )
    {
      $event.returnValue = true;
    }
  }

  constructor (
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
    private cdRef: ChangeDetectorRef,
    private publisherService: PublisherService,
    private countryService: CountryService,
    private stateService: StatesService,
    private tipoLogradouroRepo: TipologradouroService,
    private congregationService: CongregationService,
    private alertifyService: AlertifyService
  ) { }

  ngOnInit ()
  {
    //
    const token = localStorage.getItem( 'token' );
    if ( token )
    {
      this.authService.decodedToken = this.jwtHelper.decodeToken( token );
      // will use it to get real name of publisher data
      this.loadUser( this.authService.decodedToken.nameid );
    }
    //
    this.localizacao = '';
    this.initializeCongregation();
    this.setCurrentPosition();
    this.tipoLogradouro = [];
    this.selectedCountry = 0;
    this.selectedEstado = 0;
    this.selectedTipoLogradouro = 0;
    this.loadTipoLogradouro();

  }

  loadUser ( id )
  {
    console.log( 'loadUser: ' + id );
    this.userService.getUser( id ).subscribe(
      ( user: Usuario ) =>
      {
        this.user = user;
        this.getPublisher( this.user.publicadorId );
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  getPublisher ( id )
  {
    this.publisherService.getPublisher( id ).subscribe(
      ( publisher: Publicador ) =>
      {
        this.publisher = publisher;
        this.auditoriaUsuario = this.publisher.id;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );

  }

  initializeCongregation ()
  {
    this.congregation = {
      id: 0,
      nome: '',
      coordenador: '',
      padrao: false,
      tipoLogradouroId: 0,
      tipoLogradouro: null,
      nomeLogradouro: '',
      numero: '',
      complemento: '',
      bairro: '',
      cidade: '',
      estadoId: 0,
      estado: null,
      countryId: 0,
      cep: '',
      email: '',
      telCelular: '',
      telResidencial: '',
      telTrabalho: '',
      telefone: '',
      auditoriaUsuario: 0
    };
  }

  setCurrentPosition ()
  {
    console.log( 'navigator', navigator.geolocation );
    if ( navigator.geolocation )
    {
      navigator.geolocation.getCurrentPosition( position =>
      {
        const latitude = position.coords.latitude;
        const longitude = position.coords.longitude;
        console.log( 'longlat:', latitude + ' -- ' + longitude );
        this.loadCountryLocationGeonames( latitude, longitude );
      } );
    } else
    {
      console.log( 'Error Geolocation' );
    }
  }

  loadCountryLocationGeonames ( latitude: number, longitude: number )
  {
    this.countryService.displayLocationGeonames( latitude, longitude ).subscribe( response =>
    {
      this.location = response;
      this.localizacao = this.location.countryName;
      console.log( 'displayLocationGeonames====================>: ' + this.location );
      //this.countryService.searchCountry( this.localizacao ).subscribe(
      this.countryService.searchCountry( this.localizacao ).subscribe(
        ( countryRes: Country ) =>
        {
          this.searchCountry = countryRes;
          this.selectedCountry = this.searchCountry.geonameId;
          this.loadCountries();
          this.loadStateByCountry( this.selectedCountry );
          // this.loadStateByCountry(this.selectedCountry);
          // console.log('searchCountry: ' + this.selectedCountry + ' - ' + this.searchCountry.niceName);
        }
      );
    } );
  }

  /*
  displayLocation = (latitude, longitude) => {
    const url = 'http://ws.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    console.log('url: ' + url);
    console.log(this.http.get(url));
    const promise = new Promise((resolve) => {
      const apiURL = url;
      this.http.get(apiURL)
        .toPromise()
        .then(
          res => { // Success
            console.log('-----------------------------');
            console.log(res.json());
            this.location = res.json();
            console.log('-----------------------------');
            console.log(this.location.countryCode);
            console.log('-----------------------------');
            this.localizacao = this.location.countryName;
            resolve();
          }
        );
    });
    return promise;
  }
  */

  loadTipoLogradouro ()
  {
    this.tipoLogradouroRepo.getTipos().subscribe(
      ( tipoLogradouro: TipoLogradouro[] ) =>
      {
        this.tipoLogradouro = tipoLogradouro;
        this.selectedTipoLogradouro = 0;
        for ( let i = 0; i < this.tipoLogradouro.length; ++i )
        {
          this.selectedTipoLogradouro = this.tipoLogradouro[ i ].id;
          break;
        }
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadCountries ()
  {
    this.countryService.getCountries().subscribe(
      ( country: Country[] ) =>
      {
        this.country = country;
        console.log( 'Country', this.country );
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadStateByCountry ( countryId: number )
  {
    this.stateService.GetStatesByCountry( countryId ).subscribe(
      ( states: Estado[] ) =>
      {
        this.estado = states;
        this.selectedEstado = this.estado[ 0 ].geonameId;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );

  }

  createCongregation ( congregacao: Congregacao )
  {

    console.log( 'createCongregation' );

    congregacao.auditoriaUsuario = this.auditoriaUsuario;

    console.log( congregacao );

    this.congregationService.createCongregation( congregacao ).subscribe(
      ( result: Congregacao ) =>
      {
        console.log( result );
        this.alertifyService.success( 'Congregation created successfully!' );
        this.router.navigate( [ '/congregation/' + result.id ] );
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );

  }

}
