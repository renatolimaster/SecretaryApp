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
import { PreventUnsaveChanges } from './_guards/prevent-unsave-changes.guard';
import { DetailFieldServiceResolver } from './_resolver/detail-fieldservice.resolver';
import { EditFieldServiceResolver } from './_resolver/edit-fieldservice.resolver';
import { InitializeFieldServiceResolver } from './_resolver/initialize-fieldservice.resolver';
import { ListFieldServiceResolver } from './_resolver/list-fieldservice.resolver';
import { ListCongregationResolver } from './_resolver/list-congregation.resolver';
import { DetailCongregationComponent } from './congregation/detail-congregation/detail-congregation.component';
import { EditCongregationComponent } from './congregation/edit-congregation/edit-congregation.component';
import { CongregationCenterComponent } from './congregation/congregation-center/congregation-center.component';
import { EditCongregationResolver } from './_resolver/edit-congregation.resolver';
import { DetailCongregationResolver } from './_resolver/detail-congregation.resolver';
import { CreateCongregationComponent } from './congregation/create-congregation/create-congregation.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: ListMembersComponent },
      { path: 'editmembers', component: EditMembersComponent },
      { path: 'detailsmembers/:id', component: DetailsMembersComponent },
      { path: 'editmembers/:id', component: EditMembersComponent },
      {
        path: 'congregation',
        component: ListCongregationComponent,
        resolve: { congregation: ListCongregationResolver }
      },
      {
        path: 'createcongregation',
        component: CreateCongregationComponent
      },
      {
        path: 'detailcongregation/:id/:del',
        component: DetailCongregationComponent,
        resolve: { congregation: DetailCongregationResolver }
      },
      {
        path: 'editcongregation/:id',
        component: EditCongregationComponent,
        resolve: { congregation: EditCongregationResolver }
      },
      { path: 'publisher', component: ListPublisherComponent },
      { path: 'assistance', component: ListAssistanceComponent },
      {
        path: 'fieldservice',
        component: ListFieldserviceComponent,
        resolve: { reports: ListFieldServiceResolver }
      },
      {
        path: 'initialize/:referenceDate',
        component: ListFieldserviceComponent,
        resolve: { reports: InitializeFieldServiceResolver }
      },
      {
        path: 'editfieldservice/:id',
        component: EditFieldserviceComponent,
        canDeactivate: [PreventUnsaveChanges],
        resolve: { report: EditFieldServiceResolver }
      },
      {
        path: 'detailfieldservice/:id/:del',
        component: DetailFieldserviceComponent,
        resolve: { report: DetailFieldServiceResolver }
      },
      {
        path: 'congregationfieldservice',
        component: CongregationFieldserviceComponent
      },
      {
        path: 'publisherfieldservice',
        component: PublisherFieldserviceComponent
      },
      { path: 'reports', component: ReportsComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
