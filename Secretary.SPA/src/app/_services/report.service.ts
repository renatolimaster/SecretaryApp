import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ServicoCampo } from '../_models/ServicoCampo';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getReports(): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice');
  }

  getInitializeFieldService(toDate): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/initialize/'  + toDate);
  }

  getReport(id): Observable<ServicoCampo> {
    return this.http.get<ServicoCampo>(this.baseUrl + 'fieldservice/' + id);
  }

  getReportsByPeriod(fromDate, toDate): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/byperiod/' + fromDate + '&' + toDate);
  }

  getReportPioneerByPeriod(fromDate, toDate, pioneerId): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/pioneerfieldservicebyperiod/' + fromDate + '&' +
    toDate  + '&' + pioneerId);
  }

  getFieldServiceByPublisherIdPeriod(fromDate, toDate, publisherId): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/fieldservicebypublisheridperiod/' + fromDate + '&' +
    toDate  + '&' + publisherId);
  }

  getUndeliveredReportsByPeriod(fromDate, toDate): Observable<ServicoCampo[]> {
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/missingfieldservice/' + fromDate + '&' + toDate);
  }

  updateReport(id: number, report: ServicoCampo) {
    return this.http.put(this.baseUrl + 'fieldservice/' + id, report);
  }
}
