import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { CountryService } from '../_services/country.service';
import { Location } from 'src/app/_interfaces/ILocation';
import { Publicador } from '../_models/Publicador';
import { Usuario } from '../_models/Usuario';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component( {
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: [ './nav.component.css' ]
} )
export class NavComponent implements OnInit
{
  @Input() publisher: Publicador;
  model: any = {};
  jwtHelper = new JwtHelperService();

  location: Location;
  country: string;

  user: Usuario;
  auditoriaUsuario: number;

  constructor (
    private countryService: CountryService,
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) { }

  ngOnInit ()
  {
    this.setCurrentPosition();
  }

  login ()
  {
    this.authService.login( this.model ).subscribe(
      () =>
      {
        this.alertify.success( 'Logged in successfully' );
      },
      error =>
      {
        this.alertify.error( error );
      },
      () =>
      {
        this.router.navigate( [ '/fieldservice' ] );
      }
    );
    this.model.username = '';
    this.model.password = '';
  }

  loggedIn ()
  {
    return this.authService.loggedIn();
  }

  logout ()
  {
    localStorage.removeItem( 'token' );
    this.alertify.message( 'logged out' );
    this.router.navigate( [ '/home' ] );
  }

  onShown (): void
  {
    console.log( 'on show' );
  }

  onHidden ()
  {
    console.log( 'on hidden' );
  }

  isOpenChange ()
  {
    console.log( 'on open change' );
  }

  setCurrentPosition ()
  {
    // console.log( 'setCurrentPosition', navigator.geolocation );
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
      this.country = this.location.countryName;
    } );
  }

}
