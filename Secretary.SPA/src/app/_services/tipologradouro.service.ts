import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { TipoLogradouro } from '../_models/TipoLogradouro';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipologradouroService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTipos(): Observable<TipoLogradouro[]> {
    console.log(this.baseUrl + 'tipologradouro');
    return this.http.get<TipoLogradouro[]>(this.baseUrl + 'tipologradouro');
  }

  getTipo(id): Observable<TipoLogradouro> {
    return this.http.get<TipoLogradouro>(this.baseUrl + 'tipologradouro/' + id);
  }
}
