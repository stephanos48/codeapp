import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef, BsDatepickerConfig } from 'ngx-bootstrap';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GeneralService } from 'src/app/_services/general.service';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Scrum } from 'src/app/_models/scrum';
import { Responsible } from 'src/app/_models/responsible';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-scrum-modal',
  templateUrl: './scrum-modal.component.html',
  styleUrls: ['./scrum-modal.component.css']
})
export class ScrumModalComponent implements OnInit {
  @Output() updateSelectedScrum = new EventEmitter();
  scrum: Scrum;
  bsConfig: Partial<BsDatepickerConfig>;
  responsibleList: Responsible[];

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService, private fb: FormBuilder,
    private http: HttpClient, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.generalService.getResponsibles().subscribe((data: Responsible[]) => { this.responsibleList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateScrum() {
    this.generalService.updateScrum(this.scrum.id, this.scrum)
      .subscribe(response => {
        console.log('Server Response: Scrum updated', response);
        this.updateSelectedScrum.emit(this.scrum);
        this.bsModalRef.hide();
      });
  }

}
