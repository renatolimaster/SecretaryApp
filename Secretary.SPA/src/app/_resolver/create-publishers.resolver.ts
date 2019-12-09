import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Publicador } from '../_models/Publicador';
import { PublisherService } from '../_services/publisher.service';

@Injectable()
export class CreatePublishersResolver implements Resolve<Publicador[]> {
    constructor(
        private publisherService: PublisherService,
        private router: Router,
        private alertfyService: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Publicador[]> {
        return this.publisherService.createPublisher(route.params['publicador']).pipe(
            catchError(() => {
                this.alertfyService.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
