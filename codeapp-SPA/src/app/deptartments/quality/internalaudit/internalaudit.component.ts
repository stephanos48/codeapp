import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { BsModalService, BsDatepickerConfig, BsModalRef } from 'ngx-bootstrap';
import { environment } from 'src/environments/environment';
import { Pagination } from 'src/app/_models/pagination';
import { Audit } from 'src/app/_models/audit';
import { InternalauditModalComponent } from './internalaudit-modal/internalaudit-modal.component';
import { QualityService } from 'src/app/_services/quality.service';

@Component({
  selector: 'app-internalaudit',
  templateUrl: './internalaudit.component.html',
  styleUrls: ['./internalaudit.component.css']
})
export class InternalauditComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  @Input() audit: Audit;
  baseUrl = environment.apiUrl;
  audits: Audit[];
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  scrumParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private qualityService: QualityService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService, private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit() {
    this.getAudits();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getAudits() {
    this.qualityService.getAudits().subscribe((audits: Audit[]) => {
      this.audits = audits;
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

  cancel() {
    this.cancelCreate.emit(false);
  }

  // to truncate date to just MM-DD-YYYY
  formatDate(date: string): string {
    const parsedDate = new Date(date);
  const formattedDate = (parsedDate.getMonth() + 1) + '-' + parsedDate.getDate() + '-' + parsedDate.getFullYear();
    return formattedDate;
  }

  createAudit() {
    if (this.createForm.valid) {
      this.audit = Object.assign({}, this.createForm.value);
      this.qualityService.createAudit(this.audit).subscribe(() => {
        this.alertify.success('Audit created successfully');
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

    editAuditsModal(audit: Audit) {
    audit.plannedAuditStartDate = new Date(audit.plannedAuditStartDate);
    // scrum.dueDate =   this.formatDate(scrum.dueDate);
    const initialState = {
      audit
    };
    this.bsModalRef = this.modalService.show(InternalauditModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedAudit.subscribe(response => {
      console.log('UPDATED AUDIT', response);
      this.alertify.success('Audit updated successfully');
      }, error => {
        console.log(error);
      });
    }

}
