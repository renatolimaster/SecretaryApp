import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { EditFieldserviceComponent } from './fieldservice/edit-fieldservice/edit-fieldservice.component';
import { DetailFieldserviceComponent } from './fieldservice/detail-fieldservice/detail-fieldservice.component';
import { PreventUnsaveChanges } from './_guards/prevent-unsave-changes.guard';
import { DetailFieldServiceResolver } from './_resolver/detail-fieldservice.resolver';
import { EditFieldServiceResolver } from './_resolver/edit-fieldservice.resolver';
import { ListFieldServiceResolver } from './_resolver/list-fieldservice.resolver';
import { MonthDatePickerComponent } from './month-date-picker/month-date-picker.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ListCongregationResolver } from './_resolver/list-congregation.resolver';
import { DetailCongregationComponent } from './congregation/detail-congregation/detail-congregation.component';
import { EditCongregationComponent } from './congregation/edit-congregation/edit-congregation.component';
import { CongregationCenterComponent } from './congregation/congregation-center/congregation-center.component';
import { EditCongregationResolver } from './_resolver/edit-congregation.resolver';
import { DetailCongregationResolver } from './_resolver/detail-congregation.resolver';
import { CreateCongregationComponent } from './congregation/create-congregation/create-congregation.component';
import { TipoLogradouroResolver } from './_resolver/list-tipologradouro.resolver';
import { ListTipologradouroComponent } from './tipologradouro/list-tipologradouro/list-tipologradouro.component';
import { InitializeFieldServiceResolver } from './_resolver/initialize-fieldservice.resolver';
import { SettingsService } from './_services/settings.service';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    // tipo logradouro
    ListTipologradouroComponent,
    // congregation
    CongregationCenterComponent,
    ListCongregationComponent,
    CreateCongregationComponent,
    DetailCongregationComponent,
    EditCongregationComponent,
    //
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
    DetailsMembersComponent,
    EditFieldserviceComponent,
    DetailFieldserviceComponent,
    MonthDatePickerComponent
  ],
  imports: [
    NgxDatatableModule,
    BrowserModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    }),
    NgbModule.forRoot(),
  ],
  providers: [
    { provide: LOCALE_ID,
      deps: [SettingsService],      // some service handling global settings
      useFactory: (settingsService) => settingsService.getLanguage()  // returns locale string
    },
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    PreventUnsaveChanges,
    // resolvers
    // field service
    DetailFieldServiceResolver,
    EditFieldServiceResolver,
    ListFieldServiceResolver,
    InitializeFieldServiceResolver,
    // congregation
    ListCongregationResolver,
    EditCongregationResolver,
    DetailCongregationResolver,
    // tipo logradouro
    TipoLogradouroResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
