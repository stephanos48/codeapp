import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Customer } from 'src/app/_models/customer';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';
import { GeneralService } from 'src/app/_services/general.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  customer: Customer;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private generalService: GeneralService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.customer = data['customer'];
    });
  }

  updateCustomer() {
    this.generalService.updateCustomer(this.customer.customerId, this.customer).subscribe(next => {
      this.alertify.success('Profile updated successfully');
      this.editForm.reset(this.customer);
    }, error => {
      this.alertify.error(error);
    });
  }

}
