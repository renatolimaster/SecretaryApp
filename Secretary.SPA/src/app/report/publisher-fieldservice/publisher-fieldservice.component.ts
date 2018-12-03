import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DateTimeExtensions } from 'src/app/_services/DateTimeExtensions';
import { ReportService } from 'src/app/_services/report.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

import * as moment from 'moment';
import { ServicoCampo } from 'src/app/_models/ServicoCampo';
import { PublisherService } from 'src/app/_services/publisher.service';
import { Publicador } from 'src/app/_models/Publicador';
import { toDate } from '@angular/common/src/i18n/format_date';

import Chart from 'chart.js';

interface Idate {
  iFromDate: Date;
  iToDate: Date;
  iPublisherId: number;
}

@Component({
  selector: 'app-publisher-fieldservice',
  templateUrl: './publisher-fieldservice.component.html',
  styleUrls: ['./publisher-fieldservice.component.css']
})
export class PublisherFieldserviceComponent implements OnInit {
  @ViewChild('myChart') myChart: ElementRef;
  title = 'Congregation Field Service';

  date: Idate;
  reports: ServicoCampo[];
  publishers: Publicador[];
  publisher: Publicador[];
  subHeader = '';
  fromDateSubHeader = '';
  toDateSubHeader = '';
  publisherId = 0;
  selectedPublisher = 0;
  totalHours = 0;
  totalCredit = 0;
  totalBethel = 0;
  totalHoursBethelCredit = 0;

  // chart
  labelsChart: any[] = [];
  dataChart: any[] = [];
  colorChart: any[] = [];
  reportsSort: ServicoCampo[];

  constructor(
    private dateTimeExtensions: DateTimeExtensions,
    private reportService: ReportService,
    private publisherService: PublisherService,
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadPublisher();
    this.title = 'Publisher Field Service';
    this.date = {
      iFromDate: this.dateTimeExtensions.FirstServiceMonth(new Date()),
      iToDate: this.dateTimeExtensions.CreateDate(1, new Date().getMonth() - 1, new Date().getFullYear()),
      iPublisherId: 0
    };
    this.labelsChart = [];
    this.dataChart = [];
    this.colorChart = [];
    this.reportsSort = [];
    this.reports = [];
    this.publishers = [];
    this.publisher = [];
    this.totalHours = 0;
    this.totalHoursBethelCredit = 0;
  }

  loadPublisher() {
    this.publisherService
      .getPublishers()
      .subscribe((publisher: Publicador[]) => {
        this.publishers = publisher;
        this.publisherId = this.publishers[0].id;
        this.subHeader = this.publishers[0].nome + ' - ' + this.publishers[0].grupo.local + ' Group';
        this.date.iFromDate = this.dateTimeExtensions.FirstServiceMonth(new Date());
        this.date.iToDate = this.dateTimeExtensions.CreateDate(1,  new Date().getMonth() - 1,  new Date().getFullYear());
        this.date.iPublisherId = this.publisherId;
        this.loadPublisherReport(this.date);
      });
  }

  loadPublisherReport(report: Idate) {
    // format to search
    const vfromDate = moment(
      this.dateTimeExtensions.FirstDayOfMonth(report.iFromDate)
    ).format('YYYY-MM-DD');
    const vtoDate = moment(
      this.dateTimeExtensions.FirstDayOfMonth(report.iToDate)
    ).format('YYYY-MM-DD');

    this.fromDateSubHeader = moment(report.iFromDate).format('MMM/YYYY');
    this.toDateSubHeader = moment(report.iToDate).format('MMM/YYYY');

    if (
      moment(this.dateTimeExtensions.FirstDayOfMonth(report.iFromDate)).isAfter(
        moment(this.dateTimeExtensions.FirstDayOfMonth(report.iToDate))
      )
    ) {
      alert(
        this.fromDateSubHeader +
          ' must be lesser than ' +
          this.toDateSubHeader +
          '!\n keep in mind that the dates will set up automatically to the first day of the month'
      );
      return;
    }

    this.publisherId = report.iPublisherId;
    this.selectedPublisher = report.iPublisherId;

    if (this.publishers.length > 0) {
      this.publisher = this.publishers.filter(
        (publ: Publicador) => publ.id.toString() === this.publisherId.toString()
      );
      this.subHeader = this.publisher[0].nome + ' - ' + this.publisher[0].grupo.local + ' Group';
    }

    this.reportService
      .getFieldServiceByPublisherIdPeriod(
        vfromDate,
        vtoDate,
        report.iPublisherId
      )
      .subscribe(
        (reports: ServicoCampo[]) => {
          // clone array
          // if use signal "=" if you modify one both will suffer the same modification
          this.reports = reports.slice(0);
          this.reportsSort = this.reports.slice(0);
          this.labelsChart = [];
          this.dataChart = [];
          this.colorChart = [];
          let count = 0;
          // sort to chart
          this.reportsSort.sort(
            (a, b) =>
              new Date(a.dataReferencia).getTime() -
              new Date(b.dataReferencia).getTime()
          );
          this.totalHours = 0;
          this.totalCredit = 0;
          this.totalBethel = 0;
          this.totalHoursBethelCredit = 0;
          this.reportsSort.forEach(element => {
            const label = moment(element.dataReferencia).format('MMM/YYYY');
            const hour = element.horas;
            this.labelsChart.push(label);
            this.dataChart.push(hour);
            this.totalHoursBethelCredit = this.totalHoursBethelCredit + element.horas + element.creditoHoras + element.horasBetel;
            this.totalHours = this.totalHours + element.horas;
            this.totalCredit = this.totalCredit + element.creditoHoras;
            this.totalBethel = this.totalBethel + element.horasBetel;
            if (count === 0) {
              this.colorChart.push('rgba(255, 99, 132, 0.2)');
              count = 1;
            } else {
              this.colorChart.push('rgba(54, 162, 235, 0.2)');
              count = 0;
            }
          });
          this.loadChart();
        },
        error => {
          this.alertifyService.error(error);
        }
      );
  }

  loadChart() {
    //////
    const ctx = this.myChart.nativeElement.getContext('2d');

    const data = {
      labels: this.labelsChart,
      datasets: [
        {
          data: this.dataChart,
          backgroundColor: this.colorChart
        }
      ]
    };

    const chart = new Chart(ctx, {
      type: 'bar',
      data: data,
      options: {
        cutoutPercentage: 40,
        // animation: {
        //   animateScale: false,
        //   animateRotate: false
        // },
        scales: {
          xAxes: [
            {
              stacked: true
            }
          ],
          yAxes: [
            {
              stacked: true
            }
          ]
        },
        title: {
          display: true,
          text: 'Publisher Field Service Chart',
          fontSize: 20,
          fontColor: '#2196F3'
        },
        legend: {
          display: false,
          labels: {
            fontColor: 'rgb(255, 99, 132)'
          }
        },
        tooltips: {
          mode: 'point'
      }
      }
    });
    /////
  }
}
