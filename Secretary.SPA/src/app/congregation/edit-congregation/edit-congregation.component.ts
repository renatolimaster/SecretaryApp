import { Component, OnInit, ChangeDetectorRef, ViewChild, HostListener } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/_models/Usuario';
import { Publicador } from 'src/app/_models/Publicador';

import { JwtHelperService } from '@auth0/angular-jwt';
import { TipoLogradouro } from 'src/app/_models/TipoLogradouro';
import { Estado } from 'src/app/_models/Estado';
import { Country } from 'src/app/_models/Country';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { PublisherService } from 'src/app/_services/publisher.service';
import { CountryService } from 'src/app/_services/country.service';
import { StatesService } from 'src/app/_services/states.service';
import { TipologradouroService } from 'src/app/_services/tipologradouro.service';
import { CongregationService } from 'src/app/_services/congregation.service';
import { AlertifyService } from 'src/app/_services/alertify.service';


import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Location } from 'src/app/_interfaces/ILocation';
import { NgForm } from '@angular/forms';

@Component( {
  selector: 'app-edit-congregation',
  templateUrl: './edit-congregation.component.html',
  styleUrls: [ './edit-congregation.component.css' ]
} )
export class EditCongregationComponent implements OnInit
{
  @ViewChild( 'editForm' )
  editForm: NgForm;
  title = 'Congregation';
  subTitles = 'Edit Congregation';
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
    if ( this.editForm.dirty )
    {
      $event.returnValue = true;
    }
  }
  constructor (
    private route: ActivatedRoute,
    private authService: AuthService,
    private userService: UserService,
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
    this.setCurrentPosition();
    this.tipoLogradouro = [];
    this.selectedCountry = 0;
    this.selectedEstado = 0;
    this.selectedTipoLogradouro = 0;
    this.loadTipoLogradouro();
    this.loadCongregation();
  }


  loadCongregation ()
  {
    // console.log( 'edit loadReport()' );
    this.route.data.subscribe( data =>
    {
      this.congregation = data[ 'congregation' ];
    } );
  }

  updateCongregation ( congregation: Congregacao )
  {
    // console.log( congregation );

    this.congregationService.updateCongregation( congregation.id, congregation ).subscribe(
      () =>
      {
        this.getCongregation( congregation.id );
        this.alertifyService.success( 'Congregation updated successfully!' );
        this.editForm.reset();
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  getCongregation ( congregationId: number )
  {

    this.congregationService.getCongregation( congregationId ).subscribe(
      ( congregation: Congregacao ) =>
      {
        // console.log( 'Congregacao:', congregation );
        this.congregation = congregation;
        this.selectedCountry = this.congregation.estado.country.id;
        this.selectedEstado = this.congregation.estado.id;
        this.selectedTipoLogradouro = this.congregation.tipoLogradouroId;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }



  loadUser ( id )
  {
    // console.log( 'loadUser: ' + id );
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

  setCurrentPosition ()
  {
    if ( navigator.geolocation )
    {
      navigator.geolocation.getCurrentPosition( position =>
      {
        const latitude = position.coords.latitude;
        const longitude = position.coords.longitude;
        this.loadCountryLocationGeonames( latitude, longitude );
      } );
    }
  }

  loadCountryLocationGeonames ( latitude: number, longitude: number )
  {
    this.countryService.displayLocationGeonames( latitude, longitude ).subscribe( response =>
    {
      this.location = response;
      this.localizacao = this.location.countryName;
      // console.log('displayLocationGeonames: ' + this.location.countryName);
      this.countryService.searchCountry( this.localizacao ).subscribe(
        ( countryRes: Country ) =>
        {
          this.searchCountry = countryRes;
          this.selectedCountry = this.searchCountry.id;
          this.loadCountries();
          this.loadStateByCountry( this.selectedCountry );
          // this.loadStateByCountry(this.selectedCountry);
          // console.log('searchCountry: ' + this.selectedCountry + ' - ' + this.searchCountry.niceName);
        }
      );
    } );
  }

  loadCountries ()
  {
    this.countryService.getCountries().subscribe(
      ( country: Country[] ) =>
      {
        this.country = country;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadStateByCountry ( id: number )
  {
    this.stateService.GetStatesByCountry( id ).subscribe(
      ( states: Estado[] ) =>
      {
        this.estado = states;
        this.selectedEstado = this.estado[ 0 ].id;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );

  }



}
