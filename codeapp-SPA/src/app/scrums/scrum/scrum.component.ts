import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { GeneralService } from 'src/app/_services/general.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { BsModalService, BsDatepickerConfig, BsModalRef } from 'ngx-bootstrap';
import { Scrum } from 'src/app/_models/scrum';
import { environment } from 'src/environments/environment';
import { Pagination } from 'src/app/_models/pagination';
import { ScrumModalComponent } from '../scrum-modal/scrum-modal.component';
import { Responsible } from 'src/app/_models/responsible';

@Component({
  selector: 'app-scrum',
  templateUrl: './scrum.component.html',
  styleUrls: ['./scrum.component.css']
})
export class ScrumComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  scrums: Scrum[];
  scrum: Scrum = JSON.parse(localStorage.getItem('scrum'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  scrumParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;
  ResponsibleList: Responsible [];

  constructor(private generalService: GeneralService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService, private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit() {
    this.getScrums();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getScrums() {
    this.generalService.getScrums().subscribe((scrums: Scrum[]) => {
      this.generalService.getResponsibles().subscribe((Response: Responsible[]) => {
        this.ResponsibleList = Response;
        this.scrums = this.formatData(scrums);
      });
         // this.scrums = scrums;
    }, error => {
      console.log(error);
    });
  }

  // to loop thru responsibles and show name instead of id
  formatData(scrums: Scrum[]): Scrum[] {
    for (let i = 0 ; i < scrums.length; i++)    {
    scrums[i].responsible =  this.ResponsibleList.filter(x => x.responsibleId === scrums[i].responsibleId)[0].employeeName;
    }
    return scrums;
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

  editScrumsModal(scrum: Scrum) {
  scrum.dueDate = new Date(scrum.dueDate);
  // scrum.dueDate =   this.formatDate(scrum.dueDate);
    const initialState = {
      scrum
    };
    this.bsModalRef = this.modalService.show(ScrumModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedScrum.subscribe(response => {
      console.log('UPDATED SCRUM', response);
      this.alertify.success('Scrum updated successfully');
      }, error => {
        console.log(error);
      });
    }

}
