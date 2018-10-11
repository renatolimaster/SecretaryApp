import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlertifyService } from './_services/alertify.service';
import { PublisherService } from './_services/publisher.service';
import { Publicador } from './_models/Publicador';
import { Usuario } from './_models/Usuario';
import { UserService } from './_services/user.service';

import * as moment from 'moment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Secretary Web';
  jwtHelper = new JwtHelperService();
  publisher: Publicador;
  publisherName: string;
  user: Usuario;

  constructor(
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private userService: UserService,
    private publisherService: PublisherService) {}

  ngOnInit(): void {
    this.publisherName = '';
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      // will use it to get real name of publisher data
      this.loadUser(this.authService.decodedToken.nameid);
      // this.getPublisher(this.user.publicadorId);
    }
  }

  loadUser(id) {
    console.log('loadUser: ' + id);
    this.userService.getUser(id).subscribe(
      (user: Usuario) => {
        this.user = user;
        this.getPublisher(this.user.publicadorId);
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  getPublisher(id) {
    console.log('getPublisher: ' + id);
    this.publisherService.getPublisher(id).subscribe(
      (publisher: Publicador) => {
        this.publisher = publisher;
        console.log('getPublisher inside: ' + this.publisher.primeiroNome + ' - ' + this.publisher.nomeSobrenome);
        this.publisherName = '(' + this.publisher.nomeSobrenome + ')';
      },
      error => {
        this.alertifyService.error(error);
      }
    );

  }
}
