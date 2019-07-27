import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Observable } from 'rxjs';
import { Customer } from '../_models/customer';
import { Scrum } from '../_models/scrum';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getCustomers() {
  return this.http.get(this.baseUrl + 'customers/getCustomers');
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

}


