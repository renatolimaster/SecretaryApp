import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estado } from '../_models/Estado';
import { Country } from '../_models/Country';


@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getStates(): Observable<Country[]> {
    console.log(this.baseUrl + 'country');
    return this.http.get<Country[]>(this.baseUrl + 'country');
  }

  getState(id): Observable<Country> {
    return this.http.get<Country>(this.baseUrl + 'country/' + id);
  }

}

