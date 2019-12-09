import { Component, OnInit, ViewChild, Input, HostListener, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Congregacao } from 'src/app/_models/Congregacao';
import { Pioneiro } from 'src/app/_models/Pioneiro';
import { Publicador } from 'src/app/_models/Publicador';
import { PublisherService } from 'src/app/_services/publisher.service';
import { PioneerService } from 'src/app/_services/pioneer.service';
import { CongregationService } from 'src/app/_services/congregation.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { Usuario } from 'src/app/_models/Usuario';
import { UserService } from 'src/app/_services/user.service';

@Component( {
  selector: 'app-create-publisher',
  templateUrl: './create-publisher.component.html',
  styleUrls: [ './create-publisher.component.css' ]
} )
export class CreatePublisherComponent implements OnInit
{
  @ViewChild( 'editForm' ) editForm: NgForm;
  @Input() modalRef: BsModalRef;
  bsModalRef: BsModalRef;
  title = 'Publisher';
  subTitles = 'Create'
  congregations: Congregacao[] = [];
  sexo: boolean;
  pioneers: Pioneiro[] = [];
  publishers: Publicador[];
  user: Usuario;
  loggedPublisher: Publicador;
  selectedCongregation: number;
  selectedPioneer: number;
  selectedPublisher: number;
  publisherName: string;
  situacaoServicoCampo: string;

  myDateValue: Date;

  @HostListener( 'window:beforeunload', [ '$event' ] )
  unloadNotification ( $event: any )
  {
    if ( this.editForm.dirty )
    {
      $event.returnValue = true;
    }
  }

  constructor (
    private modalService: BsModalService,
    private cdRef: ChangeDetectorRef,
    private publisherService: PublisherService,
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService,
    public authService: AuthService,
    public userService: UserService
  )
  {

  }

  ngOnInit ()
  {
    this.loadLoggedUserData();
    this.myDateValue = new Date();
    this.selectedPioneer = 1;
    this.selectedPublisher = 0;
    this.sexo = true;
    this.loadPioneers();
    this.loadPublishers();
  }

  loadLoggedUserData ()
  {
    let userLogged = this.authService.getUserLogged();
    this.userService.getUser( userLogged.nameid ).subscribe( user =>
    {
      this.user = user;
      this.publisherService.getPublisher( this.user.publicadorId ).subscribe( ( publisher: Publicador ) =>
      {
        this.loggedPublisher = publisher;
        if ( this.loggedPublisher )
        {
          this.selectedCongregation = this.loggedPublisher.congregacaoId;
          this.loadCongregation( this.selectedCongregation );
        } else
        {
          this.selectedCongregation = 0;
          this.loadCongregations( this.selectedCongregation );
        }
      }, error =>
      {
        this.alertifyService.error( error );
      } );
    } );
  }

  loadCongregations ( id: number )
  {
    this.congregationService.getCongregations().subscribe(
      ( congregations: Congregacao[] = [] ) =>
      {
        this.congregations = congregations;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadCongregation ( id: number )
  {
    this.congregationService.getCongregation( id ).subscribe( ( congregation: Congregacao ) =>
    {
      this.congregations.push( congregation );
    } );
  }

  loadPioneers ()
  {
    this.pioneerService.getPioneers().subscribe(
      ( pioneers: Pioneiro[] ) =>
      {
        this.pioneers = pioneers;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  loadPublishers ()
  {
    this.publisherService.getPublishers().subscribe(
      ( publishers: Publicador[] ) =>
      {
        this.publishers = publishers;
      },
      error =>
      {
        this.alertifyService.error( error );
      }
    );
  }

  onDateChange ( newDate: Date )
  {
    console.log( newDate );
  }

}
