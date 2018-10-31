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

  getReport(id): Observable<ServicoCampo> {
    return this.http.get<ServicoCampo>(this.baseUrl + 'fieldservice/' + id);
  }

  getReportsByPeriod(fromDate, toDate): Observable<ServicoCampo[]> {
    console.log('period: ' + fromDate + ' - ' + toDate);
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/byperiod/' + fromDate + '&' + toDate);
  }

  getReportPioneerByPeriod(fromDate, toDate, pioneerId): Observable<ServicoCampo[]> {
    console.log('period: ' + fromDate + ' - ' + toDate  + ' - ' + pioneerId);
    return this.http.get<ServicoCampo[]>(this.baseUrl + 'fieldservice/pioneerfieldservicebyperiod/' + fromDate + '&' +
    toDate  + '&' + pioneerId);
  }

  updateReport(id: number, report: ServicoCampo) {
    console.log('id: ' + id + ' reportId: ' + report.congregacao.id + ' - ' + report.congregacaoId);
    console.log(report);
    return this.http.put(this.baseUrl + 'fieldservice/' + id, report);
  }
}
