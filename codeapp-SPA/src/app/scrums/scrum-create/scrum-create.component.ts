import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { GeneralService } from 'src/app/_services/general.service';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Responsible } from 'src/app/_models/responsible';
import { Scrum } from 'src/app/_models/scrum';

@Component({
  selector: 'app-scrum-create',
  templateUrl: './scrum-create.component.html',
  styleUrls: ['./scrum-create.component.css']
})
export class ScrumCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  formData: Scrum;
  bsConfig: Partial<BsDatepickerConfig>;
  responsibleList: Responsible[];

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private alertify: AlertifyService) { }

  ngOnInit() {
    this.generalService.getResponsibles().subscribe((data: Responsible[]) => {this.responsibleList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  create() {
    this.generalService.createScrum(this.model).subscribe(() => {
      console.log('scrum created successfully');
      // this.router.navigateByUrl('/scrum');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/scrum']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
