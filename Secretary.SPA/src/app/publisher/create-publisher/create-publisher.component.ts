import { Component, OnInit, ViewChild, Input, HostListener, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Congregacao } from 'src/app/_models/Congregacao';
import { Pioneiro } from 'src/app/_models/Pioneiro';
import { Publicador } from 'src/app/_models/Publicador';
import { Dianteira } from 'src/app/_models/Dianteira';
import { Grupo } from 'src/app/_models/Grupo';
import { Estado } from 'src/app/_models/Estado';
import { Cidade } from 'src/app/_models/Cidade';
import { TipoLogradouro } from 'src/app/_models/TipoLogradouro';
import { Situacao } from 'src/app/_models/Situacao';
import { Country } from 'src/app/_models/Country';
import { PublisherService } from 'src/app/_services/publisher.service';
import { PioneerService } from 'src/app/_services/pioneer.service';
import { CongregationService } from 'src/app/_services/congregation.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { Usuario } from 'src/app/_models/Usuario';
import { UserService } from 'src/app/_services/user.service';
import { GroupService } from 'src/app/_services/group.service';
import { TipologradouroService } from 'src/app/_services/tipologradouro.service';
import { CountryService } from 'src/app/_services/country.service';
import { StatesService } from 'src/app/_services/states.service';
import { Location } from 'src/app/_interfaces/ILocation';
import { SituationService } from 'src/app/_services/situation.service';
import { flattenStyles } from '@angular/platform-browser/src/dom/dom_renderer';

@Component( {
  selector: 'app-create-publisher',
  templateUrl: './create-publisher.component.html',
  styleUrls: [ './create-publisher.component.css' ]
} )
export class CreatePublisherComponent implements OnInit
{
  @ViewChild( 'editForm' ) editForm: NgForm;
  @Input() modalRef: BsModalRef;
  bsModalRef: BsModalRef;
  title = 'Publisher';
  subTitles = 'Create';
  congregations: Congregacao[] = [];
  congregation: Congregacao;
  sexo: boolean;
  pioneers: Pioneiro[] = [];
  pioneer: Pioneiro;
  numeroPioneiro: string;
  publishers: Publicador[] = [];
  publisher: Publicador;
  dianteira: Dianteira;
  situation: Situacao;
  situations: Situacao[] = [];
  selectedSituation: number;
  group: Grupo;
  groups: Grupo[] = [];
  selectedGroup: number;
  tipoLogradouros: TipoLogradouro[] = [];
  tipoLogradouro: TipoLogradouro;
  selectedTipoLogradouro: number;
  situacao: Situacao;
  user: Usuario;
  loggedPublisher: Publicador;
  selectedCongregation: number;
  selectedPioneer: number;
  selectedPublisher: number;
  publisherName: string;
  situacaoServicoCampo: string;
  estado: Estado[];
  state: Estado;
  selectedEstado: number;
  countries: Country[] = [];
  country: Country;
  searchCountry: Country;
  publisherCounty: Country;

  city: Cidade;
  cities: Cidade[] = [];
  selectedCity: number;
  cityName: string;
  selectedCountry: number;
  setPosition: any;
  lng: any;
  lat: any;
  location: Location;
  locationCountry: Location[];
  localizacao: number;

  @HostListener( 'window:beforeunload', [ '$event' ] )
  unloadNotification ( $event: any )
  {
    if ( this.editForm.dirty )
    {
      $event.returnValue = true;
    }
  }

  constructor (
    private modalService: BsModalService,
    private cdRef: ChangeDetectorRef,
    private publisherService: PublisherService,
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService,
    private authService: AuthService,
    private userService: UserService,
    private groupService: GroupService,
    private tipoLogradouroService: TipologradouroService,
    private countryService: CountryService,
    private stateService: StatesService,
    private situationService: SituationService

  )
  { }

  ngOnInit ()
  {
    this.initialize();
  }

  initialize ()
  {
    this.initializeVariables();
    this.setCurrentPosition();
    this.loadPioneers();
    this.loadTipoLogradouro();
    this.loadLoggedUserData();
  }

  initializeVariables ()
  {
    this.selectedCongregation = 0;
    this.selectedCountry = 0;
    this.selectedEstado = 0;
    this.selectedGroup = 0;
    this.selectedPioneer = 0;
    this.selectedPublisher = 0;
    this.selectedTipoLogradouro = 0;
    this.cityName = '';
    this.numeroPioneiro = '0';
    this.initializePublisher();
  }

  resetForm ()
  {
    this.editForm.reset();
    this.initialize();
  }

  setCurrentPosition ()
  {
    // console.log( 'navigator', navigator.geolocation );
    if ( navigator.geolocation )
    {
      navigator.geolocation.getCurrentPosition( position =>
      {
        let latitude = position.coords.latitude;
        let longitude = position.coords.longitude;
        // console.log( 'position:', position );
        this.loadCountryLocationGeonames( latitude, longitude );
      }, error =>
      {
        console.log( 'Geolocation is not supported by this browser.', error );
      } );
    }
  }


  loadCountryLocationGeonames ( lat: number, lng: number )
  {
    this.countryService.getCityByCoordinates( lat, lng ).subscribe( ( city: any ) =>
    {
      this.city = city.geonames[ 0 ];
      console.log( 'City', this.city.toponymName );
      this.cityName = this.city.toponymName;
      this.localizacao = this.city.geonameId;
      this.countryService.getCountry().subscribe(
        ( countryRes: any ) =>
        {
          this.countries = countryRes.geonames;
          this.country = this.countries.find( c => c.geonameId === +this.city.countryId );
          this.selectedCountry = this.country.geonameId;
          this.loadStateByCountry( this.country.geonameId );
        },
        error =>
        {
          this.alertifyService.error( error );
        }
      );
    } );
  }
  loadStateByCountry ( countryId: number )
  {
    console.log( 'loadStateByCountry', countryId );
    this.countryService.getStatesByCountry( countryId ).subscribe(
      ( states: any ) =>
      {
        this.estado = states.geonames;
        this.selectedEstado = this.estado[0].geonameId;
        // console.log( 'selectedEstado:', this.selectedEstado );
        this.loadCitiesByState( this.selectedEstado );
        this.initializePublisher();
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );

  }

  loadCitiesByState ( geonameId: number )
  {
    console.log( 'loadCitiesByState', geonameId );
    this.countryService.getCityByGeonameId( geonameId ).subscribe( ( cities: any ) =>
    {
      this.cities = cities.geonames;
      // console.log( 'Cities:', this.cities );
      this.selectedCity = this.cities[ 0 ].geonameId;
      this.city = this.cities[0];
    }, error =>
    {
      console.log( 'loadCitiesByState', error );
    } );

  }

  changeBaptism ( baptism: Date )
  {
    console.log( 'baptism:', baptism );
    if ( baptism )
    {
      this.publisher.irmaoBatizado = true;
    } else
    {
      this.publisher.irmaoBatizado = false;
    }
  }

  loadLoggedUserData ()
  {
    let userLogged = this.authService.getUserLogged();
    this.userService.getUser( userLogged.nameid ).subscribe( user =>
    {
      this.user = user;
      this.publisherService.getPublisher( this.user.publicadorId ).subscribe( ( publisher: Publicador ) =>
      {
        this.loggedPublisher = publisher;
        if ( this.loggedPublisher )
        {
          this.selectedCongregation = this.loggedPublisher.congregacaoId;
          this.loadSituation( this.selectedCongregation );
          this.loadCongregation( this.selectedCongregation );
          this.loadGroups();
        } else
        {
          this.selectedCongregation = 0;
          this.loadCongregations( this.selectedCongregation );
        }
      }, error =>
      {
        this.alertifyService.error( error );
      } );
    } );
  }
  loadSituation ( selectedCongregation: number )
  {
    this.situationService.getSituations( selectedCongregation ).subscribe( ( sit: Situacao[] ) =>
    {
      this.situations = sit;
      // console.log( this.situations );
      this.selectedSituation = this.situations[ 0 ].id;
    },
      error =>
      {
        this.alertifyService.error( error );
      } );
  }

  loadGroups ()
  {
    this.groupService.getGroups( this.selectedCongregation ).subscribe( groups =>
    {
      this.groups = groups.filter( g => g.local !== 'Transfers' );
      this.selectedGroup = this.groups[ 0 ].id;
    },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadCongregations ( id: number )
  {
    this.congregationService.getCongregations().subscribe(
      ( congregations: Congregacao[] = [] ) =>
      {
        this.congregations = congregations;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadCongregation ( id: number )
  {
    this.congregationService.getCongregation( id ).subscribe( ( congregation: Congregacao ) =>
    {
      this.congregations.push( congregation );
    } );
  }

  loadPioneers ()
  {
    this.pioneerService.getPioneers().subscribe(
      ( pioneers: Pioneiro[] ) =>
      {
        this.pioneers = pioneers;
        this.pioneer = this.pioneers[ 0 ];
        this.selectedPioneer = this.pioneer.id;
        this.numeroPioneiro = '0';
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadTipoLogradouro ()
  {
    this.tipoLogradouroService.getTipos().subscribe( ( tipo: TipoLogradouro[] ) =>
    {
      this.tipoLogradouros = tipo;
      this.selectedTipoLogradouro = this.tipoLogradouros[ 0 ].id;
    },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  onDateChange ( newDate: Date )
  {
    console.log( newDate );
  }

  initializePublisher ()
  {
    this.publisher = {
      id: 0,
      nome: '',
      primeiroNome: '',
      nomeSobrenome: '',
      dataNascimento: null,
      anointed: false,
      age: 0,
      dianteiraId: 0,
      dianteira: this.dianteira,
      grupoId: 0,
      grupo: this.group,
      pioneiroId: 0,
      numeroPioneiro: '0',
      pioneiro: this.pioneer,
      sexo: true,
      situacaoServicoCampo: 'Irregular',
      telCelular: '',
      congregacaoId: 0,
      congregacao: this.congregation,
      estado: this.state,
      cep: '',
      country: this.publisherCounty,
      tipoLogradouro: this.tipoLogradouro,
      complemento: '',
      nomeLogradouro: '',
      bairro: '',
      cidade: this.cityName,
      situacao: this.situacao,
      //
      irmaoBatizado: false,
      chefeFamilia: false,
      dataAnciao: null,
      dataInativo: null,
      dataInicioServico: null,
      dataReativado: null,
      dataServoMinisterial: null,
      batismo: null,
      telResidencial: '',
      telTrabalho: '',
      email: '',
    };
  }

}
