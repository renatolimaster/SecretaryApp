import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';
import { Usuario } from '../_models/Usuario';
import { UserService } from './user.service';
import { AlertifyService } from './alertify.service';
import { PublisherService } from './publisher.service';
import { Publicador } from '../_models/Publicador';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  userToken: any;
  decodedToken: any;
  jwtHelper = new JwtHelperService();
  user: Usuario;
  publisher: Publicador;
  auditoriaUsuario: number;

  constructor(
    private http: HttpClient,
    private userService: UserService,
    private alertifyService: AlertifyService,
    private publisherService: PublisherService
  ) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
