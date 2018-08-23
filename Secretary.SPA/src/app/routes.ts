import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListCongregationComponent } from './congregation/list-congregation/list-congregation.component';
import { ListPublisherComponent } from './publisher/list-publisher/list-publisher.component';
import { ListFieldserviceComponent } from './fieldservice/list-fieldservice/list-fieldservice.component';
import { ListAssistanceComponent } from './assistance/list-assistance/list-assistance.component';
import { CongregationFieldserviceComponent } from './report/congregation-fieldservice/congregation-fieldservice.component';
import { PublisherFieldserviceComponent } from './report/publisher-fieldservice/publisher-fieldservice.component';
import { ListMembersComponent } from './members/list-members/list-members.component';
import { AuthGuard } from './_guards/auth.guard';
import { ReportsComponent } from './reports/reports.component';
import { EditMembersComponent } from './members/edit-members/edit-members.component';
import { DetailsMembersComponent } from './members/details-members/details-members.component';
import { EditFieldserviceComponent } from './fieldservice/edit-fieldservice/edit-fieldservice.component';
import { DetailFieldserviceComponent } from './fieldservice/detail-fieldservice/detail-fieldservice.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: ListMembersComponent, canActivate: [AuthGuard] },
      { path: 'editmembers', component: EditMembersComponent, canActivate: [AuthGuard] },
      { path: 'detailsmembers/:id', component: DetailsMembersComponent, canActivate: [AuthGuard] },
      { path: 'editmembers/:id', component: EditMembersComponent, canActivate: [AuthGuard] },
      { path: 'congregation', component: ListCongregationComponent },
      { path: 'publisher', component: ListPublisherComponent },
      { path: 'assistance', component: ListAssistanceComponent },
      { path: 'fieldservice', component: ListFieldserviceComponent },
      { path: 'editfieldservice/:id', component: EditFieldserviceComponent },
      { path: 'detailfieldservice/:id', component: DetailFieldserviceComponent },
      {
        path: 'congregationfieldservice',
        component: CongregationFieldserviceComponent
      },
      { path: 'publisherfieldservice', component: PublisherFieldserviceComponent },
      { path: 'reports', component: ReportsComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
