import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../_models/Country';
import { Location } from 'src/app/_interfaces/ILocation';


@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = environment.apiUrl;
  location: Location;
  localizacao: string;

  constructor(private http: HttpClient) {}

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.baseUrl + 'country');
  }

  getCountry(id): Observable<Country> {
    return this.http.get<Country>(this.baseUrl + 'country/' + id);
  }

  searchCountry(search): Observable<Country> {
    return this.http.get<Country>(this.baseUrl + 'country/search/' + search);
  }

  displayLocationGeonames(latitude, longitude): Observable<Location> {
    //const url = 'http://ws.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    const url = 'http://api.geonames.org/countryCodeJSON?lat=' + latitude + '&lng=' + longitude + '&username=renatolimaster';
    // this.http.get<Location>(url).subscribe(response => {
    //   this.location = response;
    // });
    return this.http.get<Location>(url);
  }

}

