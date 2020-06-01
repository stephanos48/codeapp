import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Audit } from 'src/app/_models/audit';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { QualityService } from 'src/app/_services/quality.service';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { AuditType } from 'src/app/_models/audittype';

@Component({
  selector: 'app-internalaudit-edit',
  templateUrl: './internalaudit-edit.component.html',
  styleUrls: ['./internalaudit-edit.component.css']
})
export class InternalauditEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  audit: Audit;
  photoUrl: string;
  bsConfig: Partial<BsDatepickerConfig>;
  audittypeList: AuditType[];
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
    private qualityService: QualityService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.audit = data['audit'];
    });
    this.qualityService.getAuditTypes().subscribe((data: AuditType[]) => {this.audittypeList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
    this.qualityService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
  }

  updateAudit() {
    this.qualityService.updateAudit(this.audit.auditId, this.audit).subscribe(next => {
      this.alertify.success('Audit updated successfully');
      this.editForm.reset(this.audit);
    }, error => {
      this.alertify.error(error);
    });
  }

  updateMainPhoto(photoUrl) {
    this.audit.photoUrl = photoUrl;
  }

}
