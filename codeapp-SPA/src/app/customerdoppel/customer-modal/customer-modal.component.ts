import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef, BsDatepickerConfig } from 'ngx-bootstrap';
import { Customer } from 'src/app/_models/customer';
import { GeneralService } from 'src/app/_services/general.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-customer-modal',
  templateUrl: './customer-modal.component.html',
  styleUrls: ['./customer-modal.component.css']
})
export class CustomerModalComponent implements OnInit {
  @Output() updateSelectedCustomer = new EventEmitter();
  customer: Customer;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateCustomer() {
    this.generalService.updateCustomer(this.customer.customerId, this.customer)
      .subscribe(response => {
        console.log('Server Response: Customer updated', response);
        this.updateSelectedCustomer.emit(this.customer);
        this.bsModalRef.hide();
      });
  }

  /*
  deleteCustomer(id: number) {
    this.alertify.confirm('Are you sure you want to delete this message', () => {
      this.userService.deleteMessage(id, this.authService.decodedToken.nameid).subscribe(() => {
        this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
        this.alertify.success('Message has been deleted');
      }, error => {
        this.alertify.error('Failed to delete the message');
      });
    });
  } */

}
