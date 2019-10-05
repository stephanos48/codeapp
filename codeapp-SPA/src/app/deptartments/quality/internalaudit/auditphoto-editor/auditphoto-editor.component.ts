import { Component, OnInit, Input, Output, EventEmitter, ɵConsole } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { QualityService } from 'src/app/_services/quality.service';
import { Audit } from 'src/app/_models/audit';
import { PhotoAudit } from 'src/app/_models/photoaudit';

@Component({
  selector: 'app-auditphoto-editor',
  templateUrl: './auditphoto-editor.component.html',
  styleUrls: ['./auditphoto-editor.component.css']
})
export class AuditphotoEditorComponent implements OnInit {
  @Input() photoaudits: PhotoAudit[];
  @Output() getAuditPhotoChange = new EventEmitter<string>();
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  currentMain: PhotoAudit;
  audit: any;

  constructor(private qualityService: QualityService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.initializeUploader();
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'audit/' + this.qualityService.currentAudit.auditId + '/photoaudits',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: PhotoAudit = JSON.parse(response);
        const photoaudit = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description,
          isMain: res.isMain,
          isApproved: res.isApproved
        };
        this.photoaudits.push(photoaudit);
        if (photoaudit.isMain) {
          this.qualityService.changeAuditPhoto(photoaudit.url);
          this.qualityService.currentAudit.photoUrl = photoaudit.url;
          localStorage.setItem('audit', JSON.stringify(this.qualityService.currentAudit));
        }
      }
    };
  }

  setMainPhoto(photoaudit: PhotoAudit) {
    this.qualityService.setMainPhoto(this.audit.auditId, photoaudit.id).subscribe(() => {
      this.currentMain = this.photoaudits.filter(p => p.isMain === true) [0];
      this.currentMain.isMain = false;
      photoaudit.isMain = true;
      this.qualityService.changeAuditPhoto(photoaudit.url);
      this.qualityService.currentAudit.photoUrl = photoaudit.url;
      localStorage.setItem('audit', JSON.stringify(this.qualityService.currentAudit));
    }, error => {
      this.alertify.error(error);
    });
  }

  deletePhoto(id: number) {
    this.alertify.confirm('Are you sure you want to delete this photo?', () => {
      this.qualityService.deletePhoto(this.audit.auditId, id).subscribe(() => {
        this.photoaudits.splice(this.photoaudits.findIndex(p => p.id === id), 1);
        this.alertify.success('Photo has been deleted');
      }, error => {
        this.alertify.error('Failed to delete the photo');
      });
    });
  }

}
