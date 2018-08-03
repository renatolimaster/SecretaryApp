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

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: ListMembersComponent, canActivate: [AuthGuard] },
      { path: 'congregation', component: ListCongregationComponent },
      { path: 'publisher', component: ListPublisherComponent },
      { path: 'assistance', component: ListAssistanceComponent },
      { path: 'fieldservice', component: ListFieldserviceComponent },
      {
        path: 'congregationfieldservice',
        component: CongregationFieldserviceComponent
      },
      { path: 'publisherfieldservice', component: PublisherFieldserviceComponent },
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
