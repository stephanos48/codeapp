import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule, BsDatepickerModule, PaginationModule, ButtonsModule, ModalModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import { TimeAgoPipe } from 'time-ago-pipe';
import { DataTablesModule } from 'angular-datatables';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegistserComponent } from './registser/registser.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { MemberCardComponent} from './members/member-card/member-card.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { PhotoEditorComponent } from './members/photo-editor/photo-editor.component';
import { ListsResolver } from './_resolvers/lists.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { MemberMessagesComponent } from './members/member-messages/member-messages.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { AdminService } from './_services/admin.service';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { RolesModalComponent } from './admin/roles-modal/roles-modal.component';
import { ValueComponent } from './value/value.component';
import { GeneralService } from './_services/general.service';
import { CustomerComponent } from './customer/customer.component';
import { CustomerListComponent } from './customerdoppel/customer-list/customer-list.component';
import { CustomerEditComponent } from './customerdoppel/customer-edit/customer-edit.component';
import { CustomerCreateComponent } from './customerdoppel/customer-create/customer-create.component';
import { CustomerModalComponent } from './customerdoppel/customer-modal/customer-modal.component';
import { CustomerEditResolver } from './_resolvers/customer-edit.resolver';
import { ScrumComponent } from './scrums/scrum/scrum.component';
import { ScrumListComponent } from './scrums/scrum-list/scrum-list.component';
import { ScrumCreateComponent } from './scrums/scrum-create/scrum-create.component';
import { ScrumModalComponent } from './scrums/scrum-modal/scrum-modal.component';
import { PrimeComponent } from './prime/prime.component';
import { QualityhomeComponent } from './deptartments/quality/qualityhome/qualityhome.component';
import { NcrComponent } from './deptartments/quality/ncr/ncr/ncr.component';
import { NcrModalComponent } from './deptartments/quality/ncr/ncr-modal/ncr-modal.component';
import { NcrCreateComponent } from './deptartments/quality/ncr/ncr-create/ncr-create.component';
import { InternalauditComponent } from './deptartments/quality/internalaudit/internalaudit.component';
import { InternalauditCreateComponent } from './deptartments/quality/internalaudit/internalaudit-create/internalaudit-create.component';
import { InternalauditEditComponent } from './deptartments/quality/internalaudit/internalaudit-edit/internalaudit-edit.component';
import { InternalauditModalComponent } from './deptartments/quality/internalaudit/internalaudit-modal/internalaudit-modal.component';
import { InternalauditDetailComponent } from './deptartments/quality/internalaudit/internalaudit-detail/internalaudit-detail.component';
import { AuditDetailResolver } from './_resolvers/audit-detail.resolver';
import { EngineeringComponent } from './deptartments/engineering/engineering.component';
import { HrComponent } from './deptartments/hr/hr.component';
import { InfotechComponent } from './deptartments/infotech/infotech.component';
import { LogisticsComponent } from './deptartments/logistics/logistics.component';
import { OpsComponent } from './deptartments/ops/ops.component';
import { IncinspectionComponent } from './deptartments/quality/incinspection/incinspection.component';
import { SalesComponent } from './deptartments/sales/sales.component';
import { SupplychainComponent } from './deptartments/supplychain/supplychain.component';
import { AuditphotoEditorComponent } from './deptartments/quality/internalaudit/auditphoto-editor/auditphoto-editor.component';
import { AuditEditResolver } from './_resolvers/audit-edit.resolver';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

export function tokenGetter() {
    return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegistserComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
      MemberCardComponent,
      MemberDetailComponent,
      MemberEditComponent,
      PhotoEditorComponent,
      TimeAgoPipe,
      MemberMessagesComponent,
      AdminPanelComponent,
      HasRoleDirective,
      UserManagementComponent,
      PhotoManagementComponent,
      RolesModalComponent,
      ValueComponent,
      CustomerComponent,
      CustomerListComponent,
      CustomerEditComponent,
      CustomerCreateComponent,
      CustomerModalComponent,
      ScrumComponent,
      ScrumListComponent,
      ScrumCreateComponent,
      ScrumModalComponent,
      PrimeComponent,
      QualityhomeComponent,
      NcrComponent,
      NcrModalComponent,
      NcrCreateComponent,
      InternalauditComponent,
      InternalauditCreateComponent,
      InternalauditEditComponent,
      InternalauditModalComponent,
      InternalauditDetailComponent,
      EngineeringComponent,
      HrComponent,
      InfotechComponent,
      LogisticsComponent,
      OpsComponent,
      IncinspectionComponent,
      SalesComponent,
      SupplychainComponent,
      AuditphotoEditorComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      PaginationModule.forRoot(),
      TabsModule.forRoot(),
      ButtonsModule.forRoot(),
      RouterModule.forRoot(appRoutes, {useHash: true}),
      ModalModule.forRoot(),
      NgxGalleryModule,
      FileUploadModule,
      DataTablesModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      BrowserAnimationsModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      JwtHelperService,
      AuthGuard,
      UserService,
      MemberDetailResolver,
      MemberListResolver,
      MemberEditResolver,
      PreventUnsavedChanges,
      ListsResolver,
      MessagesResolver,
      AdminService,
      GeneralService,
      CustomerEditResolver,
      AuditDetailResolver,
      AuditEditResolver,
   ],
   entryComponents:
   [
      RolesModalComponent,
      CustomerModalComponent,
      ScrumModalComponent,
      InternalauditModalComponent
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
