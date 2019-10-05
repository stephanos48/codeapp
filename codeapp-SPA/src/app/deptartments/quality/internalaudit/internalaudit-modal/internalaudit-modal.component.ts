import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { QualityService } from 'src/app/_services/quality.service';
import { BsModalRef, BsDatepickerConfig } from 'ngx-bootstrap';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Audit } from 'src/app/_models/audit';
import { AuditType } from 'src/app/_models/audittype';

@Component({
  selector: 'app-internalaudit-modal',
  templateUrl: './internalaudit-modal.component.html',
  styleUrls: ['./internalaudit-modal.component.css']
})
export class InternalauditModalComponent implements OnInit {
  @Output() updateSelectedAudit = new EventEmitter();
  audit: Audit;
  bsConfig: Partial<BsDatepickerConfig>;
  auditTypeList: AuditType[];

  constructor(public bsModalRef: BsModalRef, private qualityService: QualityService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.qualityService.getAuditTypes().subscribe((data: AuditType[]) => { this.auditTypeList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateAudit() {
    this.qualityService.updateAudit(this.audit.auditId, this.audit)
      .subscribe(response => {
        console.log('Server Response: Audit updated', response);
        this.updateSelectedAudit.emit(this.audit);
        this.bsModalRef.hide();
      });
  }

}
