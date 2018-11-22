import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Pioneiro } from '../_models/Pioneiro';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PioneerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getPioneers(): Observable<Pioneiro[]> {
    return this.http.get<Pioneiro[]>(this.baseUrl + 'pioneer');
  }

  getPioneer(id): Observable<Pioneiro> {
    return this.http.get<Pioneiro>(this.baseUrl + 'pioneer/' + id);
  }
}
