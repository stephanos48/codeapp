import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BsDatepickerConfig, BsModalRef } from 'ngx-bootstrap';
import { GeneralService } from 'src/app/_services/general.service';
import { FormBuilder } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';
import { Ncr } from 'src/app/_models/ncr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ncr-modal',
  templateUrl: './ncr-modal.component.html',
  styleUrls: ['./ncr-modal.component.css']
})
export class NcrModalComponent implements OnInit {
  @Output() updateSelectedScrum = new EventEmitter();
  ncr: Ncr;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService, private fb: FormBuilder,
    private http: HttpClient, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.generalService.getResponsibles().subscribe();
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updateNcr() {
    this.generalService.updateNcr(this.ncr.ncrId, this.ncr)
      .subscribe(response => {
        console.log('Server Response: Ncr updated', response);
        this.updateSelectedScrum.emit(this.ncr);
        this.bsModalRef.hide();
      });
  }

}
