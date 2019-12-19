import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Congregacao } from '../_models/Congregacao';

@Injectable( {
  providedIn: 'root'
} )
export class CongregationService
{
  private baseUrl = environment.apiUrl;

  constructor (
    private http: HttpClient
  ) { }

  getCongregations (): Observable<Congregacao[]>
  {
    return this.http.get<Congregacao[]>( this.baseUrl + 'congregation' );
  }

  getCongregation ( id ): Observable<Congregacao>
  {
    return this.http.get<Congregacao>( this.baseUrl + 'congregation/' + id );
  }

  createCongregation ( congregation: Congregacao )
  {
    return this.http.post<Congregacao>(
      this.baseUrl + 'congregation/', congregation );
  }

  updateCongregation ( id: number, congregation: Congregacao )
  {
    console.log( 'url: ' + this.baseUrl + 'congregation/' + id + ' - ' + congregation );
    console.log( congregation );
    return this.http.put( this.baseUrl + 'congregation/' + id, congregation );
  }

  deleteCongregation ( id: number )
  {
    console.log( 'url: ' + this.baseUrl + 'deletecongregation/' + id );
    return this.http.delete( this.baseUrl + 'congregation/' + id );
  }
}
