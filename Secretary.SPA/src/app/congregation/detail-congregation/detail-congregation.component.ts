import { Component, OnInit } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { TipoLogradouro } from 'src/app/_models/TipoLogradouro';
import { CongregationService } from 'src/app/_services/congregation.service';

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
    private router: Router,
    private route: ActivatedRoute,
    private congregationService: CongregationService,
    private alertifyService: AlertifyService
    ) { }

  ngOnInit() {
    this.catchParams();
    this.loadCongregation();
  }

  catchParams() {
    this.del = <boolean>this.route.snapshot.params['del'];
    if (this.del === 'true') {
      this.subTitles = 'Delete';
    } else {
      this.subTitles = 'Details';
    }
  }

  loadCongregation() {
    this.route.data.subscribe(data => {
      this.congregation = data['congregation'];
    });
  }

  deleteFieldService(id: number) {
    this.congregationService.deleteCongregation(id).subscribe(
      () => {
        this.alertifyService.success('Congregation deleted successfully!');
        this.router.navigate(['/congregation']);
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

}
