import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { GeneralService } from 'src/app/_services/general.service';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {

  }

  create() {
    this.generalService.createCustomer(this.model).subscribe(() => {
      console.log('customer created successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/customerlist']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
