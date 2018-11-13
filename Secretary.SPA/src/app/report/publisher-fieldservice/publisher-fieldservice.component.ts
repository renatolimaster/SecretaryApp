import { Component, OnInit } from '@angular/core';
import { DateTimeExtensions } from 'src/app/_services/DateTimeExtensions';
import { ReportService } from 'src/app/_services/report.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

import * as moment from 'moment';
import { ServicoCampo } from 'src/app/_models/ServicoCampo';
import { PublisherService } from 'src/app/_services/publisher.service';
import { Publicador } from 'src/app/_models/Publicador';
import { toDate } from '@angular/common/src/i18n/format_date';

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
  }

  loadPublisher() {
    this.publisherService
      .getPublishers()
      .subscribe((publisher: Publicador[]) => {
        this.publishers = publisher;
        this.publisherId = this.publishers[0].id;
        this.subHeader = this.publishers[0].nome;
        this.date.iFromDate = this.dateTimeExtensions.FirstServiceMonth(new Date());
        this.date.iToDate = this.dateTimeExtensions.CreateDate(1, new Date().getMonth() - 1, new Date().getFullYear());
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
      this.subHeader = this.publisher[0].nome;
    }

    this.reportService
      .getFieldServiceByPublisherIdPeriod(
        vfromDate,
        vtoDate,
        report.iPublisherId
      )
      .subscribe(
        (reports: ServicoCampo[]) => {
          this.reports = reports;
        },
        error => {
          this.alertifyService.error(error);
        }
      );
  }
}
