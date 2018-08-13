import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { ListCongregationComponent } from './congregation/list-congregation/list-congregation.component';
import { ListPublisherComponent } from './publisher/list-publisher/list-publisher.component';
import { appRoutes } from './routes';
import { ListFieldserviceComponent } from './fieldservice/list-fieldservice/list-fieldservice.component';
import { PublisherFieldserviceComponent } from './report/publisher-fieldservice/publisher-fieldservice.component';
import { CongregationFieldserviceComponent } from './report/congregation-fieldservice/congregation-fieldservice.component';
import { ListAssistanceComponent } from './assistance/list-assistance/list-assistance.component';
import { AuthGuard } from './_guards/auth.guard';
import { ListMembersComponent } from './members/list-members/list-members.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { FooterComponent } from './footer/footer.component';
import { ReportsComponent } from './reports/reports.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { EditMembersComponent } from './members/edit-members/edit-members.component';
import { DetailsMembersComponent } from './members/details-members/details-members.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    ListCongregationComponent,
    ListPublisherComponent,
    ListFieldserviceComponent,
    ListAssistanceComponent,
    PublisherFieldserviceComponent,
    CongregationFieldserviceComponent,
    ListMembersComponent,
    MemberCardComponent,
    FooterComponent,
    ReportsComponent,
    EditMembersComponent,
    DetailsMembersComponent
  ],
  imports: [
    NgxDatatableModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    })
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
