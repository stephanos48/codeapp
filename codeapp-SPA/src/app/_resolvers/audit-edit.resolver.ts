import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Audit } from '../_models/audit';
import { QualityService } from '../_services/quality.service';

@Injectable()
export class AuditEditResolver implements Resolve<Audit> {
    constructor(private qualityService: QualityService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Audit> {
        return this.qualityService.getAudit(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving your data');
                this.router.navigate(['/internalaudit']);
                return of(null);
            })
        );
    }
}
