import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Audit } from 'src/app/_models/audit';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { GeneralService } from 'src/app/_services/general.service';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuditType } from 'src/app/_models/audittype';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-internalaudit-create',
  templateUrl: './internalaudit-create.component.html',
  styleUrls: ['./internalaudit-create.component.css']
})
export class InternalauditCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  formData: Audit;
  bsConfig: Partial<BsDatepickerConfig>;
  auditTypeList: AuditType[];

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.generalService.getAuditTypes().subscribe((data: AuditType[]) => {this.auditTypeList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  create() {
    this.generalService.createAudit(this.model).subscribe(() => {
      console.log('audit created successfully');
      // this.router.navigateByUrl('/scrum');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/internalaudit']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
