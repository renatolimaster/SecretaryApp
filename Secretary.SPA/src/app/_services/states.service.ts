import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estado } from '../_models/Estado';

@Injectable({
  providedIn: 'root'
})
export class StatesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getStates(): Observable<Estado[]> {
    console.log(this.baseUrl + 'tipologradouro');
    return this.http.get<Estado[]>(this.baseUrl + 'estado');
  }

  getState(id): Observable<Estado> {
    return this.http.get<Estado>(this.baseUrl + 'estado/' + id);
  }

  GetStatesByCountry(id): Observable<Estado[]> {
    return this.http.get<Estado[]>(this.baseUrl + 'estado/statesbycountry/' + id);
  }
}

