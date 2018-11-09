import { Injectable } from '@angular/core';
import { ServicoCampo } from '../_models/ServicoCampo';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ReportService } from '../_services/report.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

export class InitializeFieldServiceResolver  implements Resolve<ServicoCampo[]> {
    constructor(
        private reportService: ReportService,
        private router: Router,
        private alertfyService: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<ServicoCampo[]> {
        return this.reportService.getInitializeFieldService(route.params['referenceDate']).pipe(
            catchError(error => {
                this.alertfyService.error('Problem retrieving data');
                this.router.navigate(['/fieldservice']);
                return of(null);
            })
        );
    }
}
