import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule, ModalModule, BsDatepickerModule, DatepickerModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
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
import { NgxDatatableModule } from '@swimlane/ngx-datatable/';
import { EditMembersComponent } from './members/edit-members/edit-members.component';
import { DetailsMembersComponent } from './members/details-members/details-members.component';
import { EditFieldserviceComponent } from './fieldservice/edit-fieldservice/edit-fieldservice.component';
import { DetailFieldserviceComponent } from './fieldservice/detail-fieldservice/detail-fieldservice.component';
import { PreventUnsaveChanges } from './_guards/prevent-unsave-changes.guard';
import { DetailFieldServiceResolver } from './_resolver/detail-fieldservice.resolver';
import { EditFieldServiceResolver } from './_resolver/edit-fieldservice.resolver';
import { ListFieldServiceResolver } from './_resolver/list-fieldservice.resolver';
import { MonthDatePickerComponent } from './month-date-picker/month-date-picker.component';
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
import { ListPublishersResolver } from './_resolver/list-publishers.resolver';
import { DetailPublisherResolver } from './_resolver/detail-publisher.resolver';
import { DetailPublisherComponent } from './publisher/detail-publisher/detail-publisher.component';
import { ModalServiceConfirmWindowComponent } from './_modals/modal-service-confirm-window/modal-service-confirm-window.component';
import { CreatePublishersResolver } from './_resolver/create-publishers.resolver';
import { CreatePublisherComponent } from './publisher/create-publisher/create-publisher.component';
import { ListGroupComponent } from './group/list-group/list-group.component';
import { EditGroupComponent } from './group/edit-group/edit-group.component';
import { CreateGroupComponent } from './group/create-group/create-group.component';
import { UpdateGroupComponent } from './group/update-group/update-group.component';
import { DetailsGroupComponent } from './group/details-group/details-group.component';
import { EditPublisherComponent } from './publisher/edit-publisher/edit-publisher.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AgmCoreModule } from '@agm/core';
import { environment } from '../environments/environment';
export function tokenGetter ()
{
  return localStorage.getItem( 'token' );
}

@NgModule( {
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
    // publisher
    ListPublisherComponent,
    PublisherFieldserviceComponent,
    DetailPublisherComponent,
    CreatePublisherComponent,
    EditPublisherComponent,
    // group
    ListGroupComponent,
    EditGroupComponent,
    CreateGroupComponent,
    UpdateGroupComponent,
    DetailsGroupComponent,
    //
    ListFieldserviceComponent,
    ListAssistanceComponent,
    //
    ModalServiceConfirmWindowComponent,
    //
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
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,

    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),

    // AGM google maps 
    AgmCoreModule.forRoot( {
      apiKey: environment.googleApiKey
    } ),

    RouterModule.forRoot( appRoutes ),
    JwtModule.forRoot( {
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: [ 'localhost:5000' ],
        blacklistedRoutes: [ 'localhost:5000/api/auth' ]
      }
    } ),
    NgbModule,
  ],
  providers: [
    {
      provide: LOCALE_ID,
      deps: [ SettingsService ],      // some service handling global settings
      useFactory: ( settingsService ) => settingsService.getLanguage()  // returns locale string
    },
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    PreventUnsaveChanges,
    // resolvers
    // PUBLISHERS
    ListPublishersResolver,
    DetailPublisherResolver,
    CreatePublishersResolver,
    //
    // field service
    DetailFieldServiceResolver,
    EditFieldServiceResolver,
    ListFieldServiceResolver,
    InitializeFieldServiceResolver,
    // congregation
    ListCongregationResolver,
    EditCongregationResolver,
    DetailCongregationResolver,
    CreateCongregationComponent,
    // Group
    // CreateGroupComponent,
    // DetailGroupComponent,
    // UpdateGroupComponent,
    // tipo logradouro
    TipoLogradouroResolver
  ],
  bootstrap: [ AppComponent ]
} )
export class AppModule { }
