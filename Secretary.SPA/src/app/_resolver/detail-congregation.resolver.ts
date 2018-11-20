import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { CongregationService } from '../_services/congregation.service';
import { Congregacao } from '../_models/Congregacao';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class DetailCongregationResolver implements Resolve<Congregacao> {
    constructor(
        private congregationService: CongregationService,
        private router: Router,
        private alertfyService: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Congregacao> {
        return this.congregationService.getCongregation(route.params['id']).pipe(
            catchError(error => {
                this.alertfyService.error('Problem retrieving congregation data');
                this.router.navigate(['/congregation']);
                return of(null);
            })
        );
    }
}
