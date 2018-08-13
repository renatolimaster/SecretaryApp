import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../_models/Usuario';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-details-members',
  templateUrl: './details-members.component.html',
  styleUrls: ['./details-members.component.css']
})
export class DetailsMembersComponent implements OnInit {
  title = 'Members';
  subTitles = 'Details';
  user: Usuario;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.userService.getUser(this.route.snapshot.params['id']).subscribe(
      (user: Usuario) => {
        this.user = user;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }
}
