import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Situacao } from '../_models/Situacao';

@Injectable( {
  providedIn: 'root'
} )
export class SituationService
{
  baseUrl = environment.apiUrl;

  constructor (
    private http: HttpClient
  ) { }

  getSituation ( situationId: number, congregationId: number ): Observable<Situacao[]>
  {
    const url = this.baseUrl + 'situation/' + situationId + '&' + congregationId;
    // console.log( 'getSituation url:', url );
    return this.http.get<Situacao[]>( url );
  }
  getSituations ( congregationId: number ): Observable<Situacao[]>
  {
    const url = this.baseUrl + 'situation/' + congregationId;
    // console.log( 'getSituations url:', url );
    return this.http.get<Situacao[]>( url );
  }





}
