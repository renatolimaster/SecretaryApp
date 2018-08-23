import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ServicoCampo } from '../_models/ServicoCampo';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  baseUrl = environment.apiUrl;

constructor(
  private http: HttpClient
) { }


getReports(): Observable<ServicoCampo[]> {
  return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice');
}

getReport(id): Observable<ServicoCampo> {
  return this.http.get<ServicoCampo>(this.baseUrl + 'fieldservice/' + id);
}

}
