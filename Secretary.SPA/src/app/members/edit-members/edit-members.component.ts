import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { Usuario } from '../../_models/Usuario';

@Component({
  selector: 'app-edit-members',
  templateUrl: './edit-members.component.html',
  styleUrls: ['./edit-members.component.css']
})
export class EditMembersComponent implements OnInit {
  title = 'Members';
  subTitles = 'Edit';
  user: Usuario;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) { }

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
