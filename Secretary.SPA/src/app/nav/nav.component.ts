import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  @Input() publisher;
  model: any = {};

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {
    console.log('veio do pai: ' + this.publisher);
  }

  login() {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/fieldservice']);
      }
    );
    this.model.username = '';
    this.model.password = '';
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }

  onShown(): void {
    console.log('on show');
  }

  onHidden() {
    console.log('on hidden');
  }

  isOpenChange() {
    console.log('on open change');
  }
}
