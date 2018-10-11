import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

import * as moment from 'moment';

interface Idate {
  fromDate: Date;
  toDate: Date;
}

@Component({
  selector: 'app-list-fieldservice',
  templateUrl: './list-fieldservice.component.html',
  styleUrls: ['./list-fieldservice.component.css']
})
export class ListFieldserviceComponent implements OnInit {
  title = 'Field Service';
  reports: ServicoCampo[];

  date: Idate;
  rows: any[] = [];
  temp = [];
  expanded: any = {};
  timeout: any;

  myForm: FormGroup;

  year: number;
  month: number;

  constructor(
    private reportService: ReportService,
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.date = {
      fromDate: new Date(2018, 5, 1),
      toDate: new Date(2018, 5, 1)
    };

    console.log('Datas: ' + new Date(2018, 5, 1));
    this.loadReports();
  }

  loadReports() {
    console.log('list loadReports()');
    this.route.data.subscribe(data => {
      this.reports = data['reports'];
      // cache our list
      this.temp = [...this.reports];
      // push our inital complete list
      this.rows = this.reports;
    });

    this.reportService.getReports().subscribe(
      (reports: ServicoCampo[]) => {
        this.reports = reports;
        // cache our list
        this.temp = [...reports];
        // push our inital complete list
        this.rows = reports;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadReportsFromPeriod(report: Idate) {
    // console.log('list loadReportsFromPeriod(): from ' + report);
    console.log(
      'list loadReportsFromPeriod(): from ' +
        moment(report.fromDate).format('YYYY-MM-DD') +
        ' - to ' +
        moment(report.toDate).format('YYYY-MM-DD')
    );
    const fromDate = moment(report.fromDate).format('YYYY-MM-DD');
    const toDate = moment(report.toDate).format('YYYY-MM-DD');
    this.route.data.subscribe(data => {
      this.reports = data['reports'];
      // cache our list
      this.temp = [...this.reports];
      // push our inital complete list
      this.rows = this.reports;
    });

    this.reportService.getReportsByPeriod(fromDate, toDate).subscribe(
      (reports: ServicoCampo[]) => {
        this.reports = reports;
        // cache our list
        this.temp = [...reports];
        // push our inital complete list
        this.rows = reports;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  onPage(event) {
    clearTimeout(this.timeout);
    this.timeout = setTimeout(() => {
      console.log('paged!', event);
    }, 100);
  }

  updateFilter(event) {
    const val = event.target.value.toLowerCase();

    // filter our data
    const temp = this.temp.filter(function(d) {
      return d.publicador.nome.toLowerCase().indexOf(val) !== -1 || !val;
    });

    // update the rows
    this.rows = temp;
    // Whenever the filter changes, always go back to the first page
    // this.table.offset = 0;
  }

  toggleExpandRow(row) {
    console.log('Toggled Expand Row!', row);
    // this.table.rowDetail.toggleExpandRow(row);
  }

  onDetailToggle(event) {
    console.log('Detail Toggled', event);
  }
}
