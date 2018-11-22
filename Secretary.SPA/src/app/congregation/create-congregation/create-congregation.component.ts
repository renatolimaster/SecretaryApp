import { Component, OnInit, ViewChild } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { TipoLogradouro } from 'src/app/_models/TipoLogradouro';
import { TipologradouroService } from 'src/app/_services/tipologradouro.service';
import { Estado } from 'src/app/_models/Estado';
import { CountryService } from 'src/app/_services/country.service';
import { Country } from 'src/app/_models/Country';
import { StatesService } from 'src/app/_services/states.service';

import { Observable } from 'rxjs';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { SettingsService } from 'src/app/_services/settings.service';
import { Location } from 'src/app/_interfaces/ILocation';

declare var google: any;

@Component({
  selector: 'app-create-congregation',
  templateUrl: './create-congregation.component.html',
  styleUrls: ['./create-congregation.component.css']
})
export class CreateCongregationComponent implements OnInit {

  title = 'Congregation';
  subTitles = 'New Congregation';
  congregation: Congregacao;
  del: any;

  tipoLogradouro: TipoLogradouro[];
  selectedTipoLogradouro: number;

  estado: Estado[];
  selectedEstado: number;

  country: Country[];
  selectedCountry: number;
  setPosition: any;

  lng: any;
  lat: any;
  location: Location;
  localizacao: string;

  // Google Maps
  bounds: google.maps.LatLngBounds;
  markers: google.maps.Marker[];
  infoWindow: google.maps.InfoWindow;

  constructor(
    private http: Http,
    private settingsService: SettingsService,
    private countryService: CountryService,
    private stateService: StatesService,
    private tipoLogradouroRepo: TipologradouroService,
    private alertifyService: AlertifyService
  ) { }

  ngOnInit() {
    this.localizacao = '';
    /*
    const latLng = new google.maps.LatLng(-34.9290, 138.6010);
    const mapOptions = {
      center: latLng,
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapOptions);
    */

    /*
    const mapProp = {
      center: new google.maps.LatLng(18.5793, 73.8143),
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);
    */

    this.setCurrentPosition();

    console.log('language: ' + this.settingsService.getLanguage());

    this.lat = 0;
    this.lng = 0;
    if (navigator.geolocation) {
      // yep, we can proceed!
      console.log('yes');
    } else {
      console.log('no');
    }

    // this.getCurrentLocation(-51.92528, -14.235004);

    this.tipoLogradouro = [];
    this.selectedCountry = 0;
    this.selectedEstado = 0;
    this.selectedTipoLogradouro = 0;
    this.loadTipoLogradouro();
    this.loadCountries();
    this.loadStateByCountry(this.selectedCountry);
    // this.displayLocation(-14.235004, -51.92528);
    // console.log('displayLocation: ' + this.location.countryName);
  }

  setCurrentPosition() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition(position => {
        const latitude = position.coords.latitude;
        const longitude = position.coords.longitude;
        console.log('lat: ' + latitude + ' - ' + longitude);
        this.displayLocation(latitude, longitude);
      });
    }
  }

  displayLocation = (latitude, longitude) => {
    const url = 'http://ws.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    console.log('url: ' + url);
    console.log(this.http.get(url));
    const promise = new Promise((resolve, reject) => {
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

  getCurrentLocation(lat: number, lng: number): Observable<any> {
    console.log('coord: ' + lat + ' - ' + lng);
    return this.http
      .get(
        'maps.googleapis.com/maps/api/geocode/json?latlng=44.4647452,7.3553838&sensor=true'
      )
      .map(
        response => {
          console.log('status-----------> : ' + response.status);
          response.json();
        },
        error => {
          console.log(error);
          return Observable.throw(error.json());
        }
      );
  }

  loadTipoLogradouro() {
    this.tipoLogradouroRepo.getTipos().subscribe(
      (tipoLogradouro: TipoLogradouro[]) => {
        this.tipoLogradouro = tipoLogradouro;
        this.selectedTipoLogradouro = 0;
        for (let i = 0; i < this.tipoLogradouro.length; ++i) {
          this.selectedTipoLogradouro = this.tipoLogradouro[i].id;
          console.log(
            'Tipos: ' +
              this.tipoLogradouro[i].id +
              ' - ' +
              this.tipoLogradouro[i].descricao
          );
          break;
        }
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadCountries() {
    this.countryService.getStates().subscribe(
      (country: Country[]) => {
        this.country = country;
        this.selectedCountry = 0;
        for (let i = 0; i < this.country.length; ++i) {
          this.selectedCountry = this.country[i].id;
          console.log(
            'country: ' + this.country[i].id + ' - ' + this.country[i].niceName
          );
          break;
        }
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadStateByCountry(id: number) {
    this.stateService.GetStatesByCountry(id).subscribe(
      (states: Estado[]) => {
        this.estado = states;
        this.selectedEstado = 0;
        for (let i = 0; i < this.estado.length; ++i) {
          this.selectedTipoLogradouro = this.estado[i].id;
          console.log(
            'states: ' + this.estado[i].id + ' - ' + this.estado[i].descricao
          );
          break;
        }
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }
}
