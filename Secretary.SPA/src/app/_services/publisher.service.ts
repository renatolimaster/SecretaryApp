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

  constructor(
    private http: HttpClient
  ) {}

  getPublishers(): Observable<Publicador[]> {
    return this.http.get<Publicador[]>(this.baseUrl + 'publisher/');
  }

  getPublisher(id): Observable<Publicador> {
    return this.http.get<Publicador>(this.baseUrl + 'publisher/' + id);
  }

  createPublisher(publisher: Publicador) {
    // const user = this.authService.decodedToken.
    return this.http.post<Publicador>(
      this.baseUrl + 'publisher/', publisher);
  }

  updatePublisher(id: number, publisher: Publicador) {
    console.log('url: ' + this.baseUrl + 'publisher/' + id + ' - ' + publisher);
    console.log(publisher);
    return this.http.put(this.baseUrl + 'publisher/' + id, publisher);
  }

  deletePublisher(id: number) {
    console.log('url: ' + this.baseUrl + 'deletepublisher/' + id);
    return this.http.delete(this.baseUrl + 'publisher/' + id);
  }
}
