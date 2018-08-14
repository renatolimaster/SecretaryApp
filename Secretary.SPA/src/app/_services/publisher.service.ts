import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Publicador } from '../_models/Publicador';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getPublishers(): Observable<Publicador[]> {
    return this.http.get<Publicador[]>(this.baseUrl + 'publisher');
  }

  getPublisher(id): Observable<Publicador> {
    return this.http.get<Publicador>(this.baseUrl + 'publisher/' + id);
  }
}
