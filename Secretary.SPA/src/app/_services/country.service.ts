import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../_models/Country';
import { Location } from 'src/app/_interfaces/ILocation';
import { Estado } from '../_models/Estado';
import { Cidade } from '../_models/Cidade';


@Injectable( {
  providedIn: 'root'
} )
export class CountryService
{
  baseUrl = environment.apiUrl;
  location: Location;
  localizacao: string;

  constructor ( private http: HttpClient ) { }

  getCountries (): Observable<Country[]>
  {
    return this.http.get<Country[]>( this.baseUrl + 'country' );
  }

  getCountry (): Observable<Country[]>
  {
    // return this.http.get<Country>(this.baseUrl + 'country/' + id);
    const url = 'http://api.geonames.org/countryInfoJSON?username=renatolimaster';
    return this.http.get<Country[]>( url );
  }

  searchCountry ( search ): Observable<Country>
  {
    const url = this.baseUrl + 'country/search/' + search;
    console.log( 'searchCountry:', url );
    return this.http.get<Country>( url );
  }

  displayLocationGeonames ( latitude: number, longitude: number ): Observable<Location>
  {
    //const url = 'http://ws.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    const url = 'http://api.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    console.log( 'displayLocationGeonames url: ', url );
    return this.http.get<Location>( url );
  }

  getStatesByCountry ( countryId: number ): Observable<Estado>
  {
    // Return countries
    // http://api.geonames.org/countryInfoJSON?username=renatolimaster
    // Returns the children (admin divisions and populated places) for a given geonameId. 
    // http://api.geonames.org/childrenJSON?geonameId=3469034&username=renatolimaster
    // Return all cities of country
    // http://api.geonames.org/searchJSON?country=BR&lang=pt&featureCode=&username=renatolimaster
    // Return geonameId
    // http://api.geonames.org/search?country=BR&username=renatolimaster&featureCode=PCLI
    // const url = 'http://api.geonames.org/neighbours?country=BR&username=renatolimaster';

    // Return city by coordinates
    // http://api.geonames.org/findNearbyJSON?lat=-20.84889&lng=-41.11278&username=renatolimaster
    // console.log( 'getStatesByCountry 2', countryId );
    const url = 'http://api.geonames.org/childrenJSON?geonameId=' + countryId + '&username=renatolimaster';
    console.log( 'getStatesByCountry:', url );
    return this.http.get<Estado>( url );
  }

  getCityByCoordinates ( lat: number, lng: number ): Observable<Cidade>
  {
    // Return countries
    // http://api.geonames.org/countryInfoJSON?username=renatolimaster
    // Returns the children (admin divisions and populated places) for a given geonameId. 
    // http://api.geonames.org/childrenJSON?geonameId=3469034&username=renatolimaster
    // Return all cities of country
    // http://api.geonames.org/childrenJSON?geonameId=3463930&username=renatolimaster
    // Return geonameId
    // http://api.geonames.org/search?country=BR&username=renatolimaster&featureCode=PCLI
    // const url = 'http://api.geonames.org/neighbours?country=BR&username=renatolimaster';

    // Return city by coordinates
    // http://api.geonames.org/findNearbyJSON?lat=-20.84889&lng=-41.11278&username=renatolimaster
    // console.log( 'getCityByCoordinates 2', lat, lng );
    const url = 'http://api.geonames.org/findNearbyJSON?lat=' + lat + '&lng=' + lng + '&username=renatolimaster';
    console.log( 'getCityByCoordinates:', url );
    return this.http.get<Cidade>( url );
  }

  getCityByGeonameId ( geonameId: number ): Observable<Cidade[]>
  {
    const url = 'http://api.geonames.org/childrenJSON?geonameId=' + geonameId + '&username=renatolimaster';
    console.log( 'getCityByGeonameId:', url );
    return this.http.get<Cidade[]>( url );
  }

}

