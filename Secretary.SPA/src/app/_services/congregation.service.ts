import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Congregacao } from '../_models/Congregacao';

@Injectable({
  providedIn: 'root'
})
export class CongregationService {
  baseUrl = environment.apiUrl;

constructor(
  private http: HttpClient
) { }


getCongregations(): Observable<Congregacao[]> {
  return this.http.get<Congregacao[]>(this.baseUrl + 'congregation');
}

getCongregation(id): Observable<Congregacao> {
  return this.http.get<Congregacao>(this.baseUrl + 'congregation/' + id);
}

}
