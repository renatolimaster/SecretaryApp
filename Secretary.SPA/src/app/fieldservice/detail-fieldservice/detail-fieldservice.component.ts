import { Component, OnInit } from '@angular/core';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-detail-fieldservice',
  templateUrl: './detail-fieldservice.component.html',
  styleUrls: ['./detail-fieldservice.component.css']
})
export class DetailFieldserviceComponent implements OnInit {
  title = 'Field Service';
  subTitles = 'Details';
  report: ServicoCampo;
  del: any;

  constructor(
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.catchParams();
    this.loadReport();
  }

  catchParams() {
    this.del = <boolean>this.route.snapshot.params['del'];
    if (this.del === 'true') {
      this.subTitles = 'Delete';
    }
    console.log('del: ' + this.del);
  }

  loadReport() {
    console.log('detail loadReport()');
    this.route.data.subscribe(data => {
      this.report = data['report'];
    });
    // this.reportService.getReport(this.route.snapshot.params['id']).subscribe(
    //   (report: ServicoCampo) => {
    //     this.report = report;
    //   },
    //   error => {
    //     this.alertifyService.error(error);
    //   }
    // );
  }

  deleteFieldService(id: number) {
    console.log('delete: ' + id);
    this.alertifyService.success('Report updated successfully!');
  }
}
