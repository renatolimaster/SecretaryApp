import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

import * as moment from 'moment';
import { DateTimeExtensions } from 'src/app/_services/DateTimeExtensions';
import { element } from 'protractor';

interface Idate {
  fromDate: Date;
  toDate: Date;
  referenceDate: Date;
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

  val: string;
  msg: string;

  myForm: FormGroup;

  year: number;
  month: number;

  constructor(
    private dateTimeExtensions: DateTimeExtensions,
    private reportService: ReportService,
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.msg = '';
    this.date = {
      fromDate: this.dateTimeExtensions.CreateDate(
        1,
        new Date().getMonth() - 1,
        new Date().getFullYear()
      ),
      toDate: this.dateTimeExtensions.CreateDate(
        1,
        new Date().getMonth() - 1,
        new Date().getFullYear()
      ),
      referenceDate: this.dateTimeExtensions.CreateDate(
        1,
        new Date().getMonth() - 1,
        new Date().getFullYear()
      )
    };

    this.loadReportsFromPeriod(this.date);
  }

  initializeFieldServices() {
    const priorMonth = moment(
      this.dateTimeExtensions.FirstDayOfMonth(new Date())
    ).subtract(1, 'months').format('YYYY-MM-DD');

    this.msg = '';

    this.reportService.getInitializeFieldService(priorMonth).subscribe(
      (reports: ServicoCampo[]) => {
        this.reports = reports;
        // cache our list
        this.temp = [...reports];
        // push our inital complete list
        this.rows = reports;
        let count = 0;
        this.reports.forEach(item => {
          if (item.horas === 0) {
            count++;
          }
        });

        if (count > 0) {
          this.msg = count + ' have not yet delivered the report!';
          this.alertifyService.error(this.msg);
        }
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadReports() {
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
    this.msg = '';

    const fromDate = moment(
      this.dateTimeExtensions.FirstDayOfMonth(report.fromDate)
    ).format('YYYY-MM-DD');
    const toDate = moment(
      this.dateTimeExtensions.FirstDayOfMonth(report.toDate)
    ).format('YYYY-MM-DD');

    if (
      moment(this.dateTimeExtensions.FirstDayOfMonth(report.fromDate)).isAfter(
        moment(this.dateTimeExtensions.FirstDayOfMonth(report.toDate))
      )
    ) {
      const from = moment(report.fromDate).format('DD/MMM/YYYY');
      const to = moment(report.toDate).format('DD/MMM/YYYY');
      alert(
        from +
          ' must be lesser than ' +
          to +
          '!\n keep in mind that the dates will set up automatically to the first day of the month'
      );
      return;
    }

    this.route.data.subscribe(data => {
      this.reports = data['reports'];
      // cache our list
      this.temp = [...this.reports];
      // push our inital complete list
      this.rows = this.reports;
      this.msg = this.reports.length + ' report(s) loaded!!';
      this.alertifyService.success(this.msg);
    });

    // this.reportService.getReportsByPeriod(fromDate, toDate).subscribe(
    //   (reports: ServicoCampo[]) => {
    //     this.reports = reports;
    //     // cache our list
    //     this.temp = [...reports];
    //     // push our inital complete list
    //     this.rows = reports;
    //     this.msg = this.reports.length + ' report(s) loaded!!';
    //     this.alertifyService.success(this.msg);
    //   },
    //   error => {
    //     this.alertifyService.error(error);
    //   }
    // );
  }

  onPage(event) {
    clearTimeout(this.timeout);
    this.timeout = setTimeout(() => {
      console.log('paged!', event);
    }, 100);
  }

  updateFilter(event) {
    this.msg = '';
    const val = event.target.value.toLowerCase();
    this.val = val;

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
