import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { GeneralService } from 'src/app/_services/general.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Ncr } from 'src/app/_models/ncr';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-ncr-create',
  templateUrl: './ncr-create.component.html',
  styleUrls: ['./ncr-create.component.css']
})
export class NcrCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  formData: Ncr;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
  };
}

create() {
  this.generalService.createNcr(this.model).subscribe(() => {
    console.log('ncr created successfully');
    // this.router.navigateByUrl('/scrum');
  }, error => {
    this.alertify.error(error);
  }, () => {
    this.router.navigate(['/ncr']);
  });
}

cancel() {
  this.cancelCreate.emit(false);
  console.log('cancelled');
}

}
