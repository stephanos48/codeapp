import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ListsResolver } from './_resolvers/lists.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerListComponent } from './customerdoppel/customer-list/customer-list.component';
import { CustomerEditComponent } from './customerdoppel/customer-edit/customer-edit.component';
import { CustomerEditResolver } from './_resolvers/customer-edit.resolver';
import { ScrumListComponent } from './scrums/scrum-list/scrum-list.component';
import { ScrumComponent } from './scrums/scrum/scrum.component';
import { PrimeComponent } from './prime/prime.component';
import { QualityhomeComponent } from './deptartments/quality/qualityhome/qualityhome.component';
import { NcrComponent } from './deptartments/quality/ncr/ncr/ncr.component';
import { InternalauditComponent } from './deptartments/quality/internalaudit/internalaudit.component';
import { InternalauditDetailComponent } from './deptartments/quality/internalaudit/internalaudit-detail/internalaudit-detail.component';
import { AuditDetailResolver } from './_resolvers/audit-detail.resolver';
import { InternalauditEditComponent } from './deptartments/quality/internalaudit/internalaudit-edit/internalaudit-edit.component';
import { AuditEditResolver } from './_resolvers/audit-edit.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
            { path: 'prime', component: PrimeComponent, data: {}},
            { path: 'home', component: HomeComponent, data: {}},
            { path: 'members/:id', component: MemberDetailComponent,
                resolve: { user: MemberDetailResolver }},
            { path: 'member/edit', component: MemberEditComponent,
                resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'messages', component: MessagesComponent, resolve: {messages: MessagesResolver} },
            { path: 'lists', component: ListsComponent, resolve: { users: ListsResolver} },
            { path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'customer1/customer', component: CustomerComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'customer', component: CustomerComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'customerlist', component: CustomerListComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'customer/edit', component: CustomerEditComponent,
            resolve: {customer: CustomerEditResolver}, canDeactivate: [PreventUnsavedChanges] },
            { path: 'scrum', component: ScrumComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'scrumlist', component: ScrumListComponent, data: {roles: ['Admin', 'Moderator']} },
            { path: 'qualityhome', component: QualityhomeComponent, data: {}},
            { path: 'ncr', component: NcrComponent, data: {}},
            { path: 'internalaudit', component: InternalauditComponent, data: {}},
            { path: 'internalaudit/edit/:id', component: InternalauditEditComponent,
            resolve: {audit: AuditEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'audit/:id', component: InternalauditDetailComponent,
            resolve: { audit: AuditDetailResolver }}
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
