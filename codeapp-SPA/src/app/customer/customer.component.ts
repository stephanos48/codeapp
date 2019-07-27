import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { GeneralService } from 'src/app/_services/general.service';
import { Customer } from '../_models/customer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  customers: Customer[];
  customer: Customer;
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;


  constructor(private generalService: GeneralService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService) { }

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

  createToggle() {
    this.createMode = true;
  }

  cancelCreateMode(createMode: boolean) {
    this.createMode = createMode;
  }

  createCustomerForm() {
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
  }

  cancel() {
    this.cancelCreate.emit(false);
  }

/*
  getCustomers() {
    this.http.get(this.baseUrl + 'customers').subscribe(response => {
      this.customers = response;
    }, error => {
      console.log(error);
    });
  }
*/
}
