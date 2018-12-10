import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { CongregationService } from '../_services/congregation.service';
import { Congregacao } from '../_models/Congregacao';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PublisherService } from '../_services/publisher.service';
import { Publicador } from '../_models/Publicador';

@Injectable()
export class DetailPublisherResolver implements Resolve<Publicador> {
    constructor(
        private publisherService: PublisherService,
        private router: Router,
        private alertfyService: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Publicador> {
        return this.publisherService.getPublisher(route.params['id']).pipe(
            catchError(error => {
                this.alertfyService.error('Problem retrieving publisher data');
                this.router.navigate(['/publisher']);
                return of(null);
            })
        );
    }
}
