import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { GeneralService } from '../_services/general.service';
import { Customer } from '../_models/customer';


@Injectable()
export class CustomerEditResolver implements Resolve<Customer> {
    constructor(private generalService: GeneralService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Customer> {
        return this.generalService.getCustomer(route.params['customerId']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving your data');
                this.router.navigate(['/customerlist']);
                return of(null);
            })
        );
    }
}
