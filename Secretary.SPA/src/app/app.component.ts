import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlertifyService } from './_services/alertify.service';
import { PublisherService } from './_services/publisher.service';
import { Publicador } from './_models/Publicador';
import { Usuario } from './_models/Usuario';
import { UserService } from './_services/user.service';


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
    private authService: AuthService) {}

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      // will use it to get real name of publisher data
      // this.getPublisher(this.user.publicadorId);
    } else {
      console.log('not token');
    }
  }
}
