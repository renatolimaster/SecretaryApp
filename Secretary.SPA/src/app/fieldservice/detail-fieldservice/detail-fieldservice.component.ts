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

  constructor(
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) { }

  ngOnInit() {
    this.loadReport();
  }

  loadReport() {
    this.reportService.getReport(this.route.snapshot.params['id']).subscribe(
      (report: ServicoCampo) => {
        this.report = report;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

}
