import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Congregacao } from '../_models/Congregacao';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CongregationService {
  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient,
    public authService: AuthService) {}

  getCongregations(): Observable<Congregacao[]> {
    return this.http.get<Congregacao[]>(this.baseUrl + 'congregation');
  }

  getCongregation(id): Observable<Congregacao> {
    return this.http.get<Congregacao>(this.baseUrl + 'congregation/' + id);
  }

  createCongregation(congregation: Congregacao) {
    // const user = this.authService.decodedToken.
    return this.http.post<Congregacao>(
      this.baseUrl + 'congregation/', congregation);
  }
}
