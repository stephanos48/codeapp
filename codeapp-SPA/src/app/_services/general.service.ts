import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Observable } from 'rxjs';
import { Customer } from '../_models/customer';
import { Scrum } from '../_models/scrum';
import { map } from 'rxjs/operators';
import { Ncr } from '../_models/ncr';
import { Audit } from '../_models/audit';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Division } from '../_models/division';
import { CustomerDivision } from '../_models/customerdivision';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl;
  formData: Customer;
  customerDivisions: CustomerDivision[];

constructor(private http: HttpClient) { }
/*
getScrums(page?, itemsPerPage?, scrumParams?): Observable<PaginatedResult<Scrum[]>> {
  const paginatedResult: PaginatedResult<Scrum[]> = new PaginatedResult<Scrum[]>();

  let params = new HttpParams();

  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }

  if (scrumParams != null) {
    params = params.append('scrumStatus', scrumParams.scrumStatus);
  }

  return this.http.get<Scrum[]>(this.baseUrl + 'scrums', { observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
}
*/

Form: FormGroup = new FormGroup({
  $key: new FormControl(null),
  dateCreated: new FormControl(''),
  responsibleId: new FormControl(''),
  action: new FormControl(''),
  dueDate: new FormControl(''),
  scrumStatus: new FormControl(''),
  dateCompleted: new FormControl(''),
  notes: new FormControl('')
});

/*
form: FormGroup = new FormGroup ({
  $key: new FormControl(null),
  created: new FormControl(''),
  customerName: new FormControl('', Validators.required),
  product: new FormControl(''),
  union: new FormControl(false),
  annualRevenue: new FormControl(''),
  companyStart: new FormControl(''),
  address: new FormControl(''),
  city: new FormControl(''),
  country: new FormControl(''),
  phoneNo: new FormControl(''),
  email: new FormControl(''),
  website: new FormControl(''),
  notes: new FormControl('')
});
*/

getCustomers() {
  return this.http.get(this.baseUrl + 'customers/getCustomers');
}

getCustomers1() {
  return this.http.get(this.baseUrl + 'customers/getCustomers').toPromise();
}

getCustomersPage(page?, itemsPerPage?) {
  const paginatedResult: PaginatedResult<Customer[]> = new PaginatedResult<Customer[]>();

  let params = new HttpParams();

  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }

  return this.http.get<Customer[]>(this.baseUrl + 'customers', { observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

  updateCustomer(id: number, customer: Customer) {
    return this.http.put(this.baseUrl + 'customers/' + id, customer);
  }

  createCustomer(customer: Customer) {
    return this.http.post(this.baseUrl + 'customers/createCustomer', customer);
  }

  getCustomer(id): Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl + 'customers/' + id);
  }

  deleteCustomer1(id: number, customer: Customer) {
    return this.http.post(this.baseUrl + 'customers/' + id, customer).toPromise();
  }

  deleteCustomer(id: number, customer: Customer) {
    return this.http.post(this.baseUrl + 'customers/' + id, customer);
  }

  getScrums() {
    return this.http.get(this.baseUrl + 'scrums/getScrums');
  }

  updateScrum(id: number, scrum: Scrum) {
    return this.http.put(this.baseUrl + 'scrums/' + id, scrum);
  }

  createScrum(scrum: Scrum) {
    return this.http.post(this.baseUrl + 'scrums/createScrum', scrum);
  }

  getScrum(id): Observable<Scrum> {
    return this.http.get<Scrum>(this.baseUrl + 'scrums/' + id);
  }

  deleteScrum(id: number, scrum: Scrum) {
    return this.http.post(this.baseUrl + 'scrums/' + id, scrum);
  }

  getResponsibles() {
    return this.http.get(this.baseUrl + 'responsibles/getResponsibles');
  }

  getNcrs() {
    return this.http.get(this.baseUrl + 'ncrs/getNcrs');
  }

  updateNcr(id: number, ncr: Ncr) {
    return this.http.put(this.baseUrl + 'ncrs/' + id, ncr);
  }

  createNcr(ncr: Ncr) {
    return this.http.post(this.baseUrl + 'ncrs/createNcr', ncr);
  }

  getNcr(id): Observable<Ncr> {
    return this.http.get<Ncr>(this.baseUrl + 'ncrs/' + id);
  }

  deleteNcr(id: number, ncr: Ncr) {
    return this.http.post(this.baseUrl + 'ncrs/' + id, ncr);
  }

  getAudits() {
    return this.http.get(this.baseUrl + 'audit/getAudits');
  }

  updateAudit(id: number, audit: Audit) {
    return this.http.put(this.baseUrl + 'audit/' + id, audit);
  }

  createAudit(audit: Audit) {
    return this.http.post(this.baseUrl + 'audit/createAudit', audit);
  }

  getAudit(id): Observable<Audit> {
    return this.http.get<Audit>(this.baseUrl + 'audit/' + id);
  }

  deleteAudit(id: number, audit: Audit) {
    return this.http.post(this.baseUrl + 'audit/' + id, audit);
  }

  getAuditTypes() {
    return this.http.get(this.baseUrl + 'auditTypes/getAuditTypes');
  }

}


