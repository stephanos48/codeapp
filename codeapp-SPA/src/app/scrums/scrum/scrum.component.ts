import { Component, OnInit, Output, EventEmitter, ViewChild, ChangeDetectorRef, OnDestroy, AfterViewInit,
  Inject, ElementRef } from '@angular/core';
import { GeneralService } from 'src/app/_services/general.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { BsModalService, BsDatepickerConfig, BsModalRef } from 'ngx-bootstrap';
import { Scrum } from 'src/app/_models/scrum';
import { environment } from 'src/environments/environment';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { ScrumModalComponent } from '../scrum-modal/scrum-modal.component';
import { Responsible } from 'src/app/_models/responsible';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatPaginator, MatTableDataSource, MatSort, MatTable, MatIcon, MatCheckbox, MatDialog, MatDialogRef } from '@angular/material';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { DialogBoxComponent } from 'src/app//dialog-box/dialog-box.component';

@Component({
  selector: 'app-scrum',
  templateUrl: './scrum.component.html',
  styleUrls: ['./scrum.component.css']
})
export class ScrumComponent implements OnInit, AfterViewInit {
  @Output() cancelCreate = new EventEmitter();
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatTable, {static: true}) table: MatTable<any>;
  @ViewChild('filter', { static: true }) filter: ElementRef;

  displayedColumns: string [] = [ 'Created', 'Responsible', 'Action', 'Due', 'Status', 'Completed', 'Notes', 'Action' ];
  scrums: Scrum[];
  dataSource = new MatTableDataSource();
  baseUrl = environment.apiUrl;
  scrum: Scrum = JSON.parse(localStorage.getItem('scrum'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  scrumParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;
  ResponsibleList: Responsible [];
  isScrumDataLoaded: boolean;
  statusList = [{value: 'new', display: 'New'}, {value: 'inprocess', display: 'InProcess'}, {value: 'late', display: 'Late'}];
  // dtOptions: DataTables.Settings = {};
  // dataTable: any;
  // dtTrigger: Subject<any> = new Subject<any>();

  constructor(private generalService: GeneralService, private http: HttpClient, private fb: FormBuilder,
    private alertify: AlertifyService, private route: ActivatedRoute, private modalService: BsModalService,
    public dialog: MatDialog) {}

  ngOnInit(): void {
    /*this.route.data.subscribe(data => {
      this.scrums = data['scrums'].result;
      this.pagination = data['scrums'].pagination;
    });

    this.scrumParams.scrumStatus = this.scrum.scrumStatus === 'new' ? 'late' : 'new';
*/
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.getScrums();

/*
    // Detect Changes
    this.chRef.detectChanges();

    // Initiate
    const table: any = $('table');
    this.dataTable = table.DataTable();
*/ /*
    this.bsConfig = {
      containerClass: 'theme-red'
    };

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 50
    };

    this.http.get('baseUrl/scrum/getScrums')
      .pipe(map(this.extractData))
      .subscribe(scrums => {
        this.scrums = scrums;
        this.dtTrigger.next();
      }); */
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }
/*
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  private extractData(res: Response) {
    const body = res.json();
    return body.data || {};
  }
*/
/*
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadScrums();
  }

  resetFilters() {
    this.scrumParams.scrumStatus = this.scrum.scrumStatus === 'new' ? 'late' : 'new';
    this.loadScrums();
  }
  */
/*
  loadScrums() {
    this.generalService
      .getScrums(this.pagination.currentPage, this.pagination.itemsPerPage, this.scrumParams)
      .subscribe(
        (res: PaginatedResult<Scrum[]>) => {
          this.scrums = res.result;
          this.pagination = res.pagination;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }*/
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
/*
  openDialog(action, obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.event === 'Update') {
        this.updateRowData(result.data);
      } else if (result.event === 'Delete') {
        this.deleteRowData(result.data);
      }
    });
  }

  updateRowData(row_obj) {
    this.dataSource = this.dataSource.filter((value, key) => {
      if (value.id === row_obj.id) {
        value.name = row_obj.name;
      }
      return true;
    });
  }

  deleteRowData(row_obj) {
    this.dataSource = this.dataSource.filter((value, key) => {
      return value.id !== row_obj.id;
    });
  }
*/
  getScrums() {
    this.generalService.getScrums().subscribe((scrums: Scrum[]) => {
      this.generalService.getResponsibles().subscribe((Response1: Responsible[]) => {
        this.ResponsibleList = Response1;
        this.isScrumDataLoaded = true;
        this.scrums = this.formatData(scrums);
        this.dataSource.data = this.scrums;
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
