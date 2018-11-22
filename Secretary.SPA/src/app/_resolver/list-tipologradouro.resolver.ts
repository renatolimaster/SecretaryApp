import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TipoLogradouro } from '../_models/TipoLogradouro';
import { TipologradouroService } from '../_services/tipologradouro.service';

@Injectable()
export class TipoLogradouroResolver implements Resolve<TipoLogradouro[]> {
    constructor(
        private tipoService: TipologradouroService,
        private router: Router,
        private alertfyService: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<TipoLogradouro[]> {
        return this.tipoService.getTipos().pipe(
            catchError(() => {
                this.alertfyService.error('Problem retrieving tipo logradouro data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}