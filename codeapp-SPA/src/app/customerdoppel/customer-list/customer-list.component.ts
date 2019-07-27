import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { GeneralService } from 'src/app/_services/general.service';
import { Customer } from 'src/app/_models/customer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerConfig, BsModalService, BsModalRef } from 'ngx-bootstrap';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Pagination } from 'src/app/_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { CustomerModalComponent } from '../customer-modal/customer-modal.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  customers: Customer[];
  customer: Customer = JSON.parse(localStorage.getItem('customer'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  customerParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService, private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit() {
    this.getCustomers();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getCustomers() {
    this.generalService.getCustomers().subscribe((customers: Customer[]) => {
      this.customers = customers;
    }, error => {
      console.log(error);
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getCustomers();
  }

  resetFilters() {
    this.customerParams.country = this.customer.country === 'USA';
    this.getCustomers();
  }

  createToggle() {
    this.createMode = true;
  }

  cancelCreateMode(createMode: boolean) {
    this.createMode = createMode;
  }

/*   createCustomerForm() {
    this.createForm = this.fb.group({
      gender: ['male'],
      username: ['', Validators.required],
      knownAs: ['', Validators.required],
      dateOfBirth: [null, Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    });
  }


  createCustomer() {
    if (this.createForm.valid) {
      this.customer = Object.assign({}, this.createForm.value);
      this.generalService.createCustomer(this.customer).subscribe(() => {
        this.alertify.success('Customer created successfully');
      }, error => {
        this.alertify.error(error);
      });
    }
    // this.authService.register(this.model).subscribe(() => {
    //   this.alertify.success('registration successful');
    // }, error => {
    //   this.alertify.error(error);
    // });
    // console.log(this.registerForm.value);
}*/

  cancel() {
    this.cancelCreate.emit(false);
  }

  editCustomersModal(customer: Customer) {
    const initialState = {
      customer
    };
    this.bsModalRef = this.modalService.show(CustomerModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedCustomer.subscribe(response => {
      console.log('UPDATED CUSTOMER', response);
      this.alertify.success('Customer updated successfully');
      }, error => {
        console.log(error);
      });
    }
  }
