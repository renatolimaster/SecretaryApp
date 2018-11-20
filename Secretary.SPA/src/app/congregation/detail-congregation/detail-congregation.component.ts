import { Component, OnInit } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-detail-congregation',
  templateUrl: './detail-congregation.component.html',
  styleUrls: ['./detail-congregation.component.css']
})
export class DetailCongregationComponent implements OnInit {
  title = 'Congregation';
  subTitles = 'Details';
  congregation: Congregacao;
  del: any;

  constructor(
    private route: ActivatedRoute,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.catchParams();
    this.loadCongregation();
  }

  catchParams() {
    this.del = <boolean>this.route.snapshot.params['del'];
    if (this.del === 'true') {
      this.subTitles = 'Delete';
    }
  }

  loadCongregation() {
    this.route.data.subscribe(data => {
      this.congregation = data['congregation'];
    });
  }

  deleteFieldService(id: number) {
    this.alertifyService.success('Report updated successfully!');
  }

}
