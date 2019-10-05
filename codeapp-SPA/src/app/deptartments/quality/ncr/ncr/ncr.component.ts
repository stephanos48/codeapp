import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { GeneralService } from 'src/app/_services/general.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalService, BsDatepickerConfig, BsModalRef } from 'ngx-bootstrap';
import { environment } from 'src/environments/environment';
import { Pagination } from 'src/app/_models/pagination';
import { Ncr } from 'src/app/_models/ncr';
import { NcrModalComponent } from '../ncr-modal/ncr-modal.component';

@Component({
  selector: 'app-ncr',
  templateUrl: './ncr.component.html',
  styleUrls: ['./ncr.component.css']
})
export class NcrComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  ncrs: Ncr[];
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  customerParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService, private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit() {
    this.getNcrs();

    this.bsConfig = {
      containerClass: 'theme-red'
  };
}

getNcrs() {
  this.generalService.getCustomers().subscribe((ncrs: Ncr[]) => {
    this.ncrs = ncrs;
  }, error => {
    console.log(error);
  });
}

pageChanged(event: any): void {
  this.pagination.currentPage = event.page;
  this.getNcrs();
}

createToggle() {
  this.createMode = true;
}

cancelCreateMode(createMode: boolean) {
  this.createMode = createMode;
}

editNcrsModal(ncr: Ncr) {
  ncr.dateCreated = new Date(ncr.dateCreated);
  // scrum.dueDate =   this.formatDate(scrum.dueDate);
    const initialState = {
      ncr
    };
    this.bsModalRef = this.modalService.show(NcrModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedScrum.subscribe(response => {
      console.log('UPDATED NCR', response);
      this.alertify.success('Ncr updated successfully');
      }, error => {
        console.log(error);
      });
    }

}
