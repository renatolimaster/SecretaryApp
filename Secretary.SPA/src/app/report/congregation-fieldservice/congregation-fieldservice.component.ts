import { Component, OnInit } from '@angular/core';
import { ReportService } from 'src/app/_services/report.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

import * as moment from 'moment';
import { DateTimeExtensions } from 'src/app/_services/DateTimeExtensions';
import { ServicoCampo } from 'src/app/_models/ServicoCampo';
import { IDate } from 'src/app/_interfaces/IDate';
import { ITotalFieldServiceReport } from 'src/app/_interfaces/ITotalFieldServiceReport';
import { FormGroup } from '@angular/forms';
import { IFieldServiceReportPdf } from 'src/app/_interfaces/IFieldServiceReportPdf';

import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';

pdfMake.vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-congregation-fieldservice',
  templateUrl: './congregation-fieldservice.component.html',
  styleUrls: ['./congregation-fieldservice.component.css']
})
export class CongregationFieldserviceComponent implements OnInit {
  title = 'Congregation Field Service';
  reports: ServicoCampo[];
  date: IDate;
  totalsPublishers: ITotalFieldServiceReport;
  totalsAuxiliar: ITotalFieldServiceReport;
  totalsAuxiliar30: ITotalFieldServiceReport;
  totalsAuxiliarRegular: ITotalFieldServiceReport;
  totalsRegular: ITotalFieldServiceReport;
  totalsEspecial: ITotalFieldServiceReport;
  totals: ITotalFieldServiceReport;

  dataReport: IFieldServiceReportPdf;
  datePdf: Date;

  totalPublishers = 0;
  totalAuxiliar = 0;
  totalAuxiliar30 = 0;
  totalAuxiliarRegular = 0;
  totalRegular = 0;
  totalEspecial = 0;

  totalReport = [];

  totalPublishersReport = [];
  totalAuxiliarReport = [];
  totalAuxiliar30Report = [];
  totalAuxiliarRegularReport = [];
  totalRegularReport = [];
  totalEspecialReport = [];

  pioneerId = 0;
  totalPublisher = 0;
  totalPublisherDelivered = 0;
  totalDelivered = 0;
  totalHourBetelCredit = 0;

  myForm: FormGroup;

  constructor(
    private dateTimeExtensions: DateTimeExtensions,
    private reportService: ReportService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
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
      )
    };

    this.initializeValues();

    console.log('Datas: ' + this.date.fromDate);
    // this.loadReports();

    this.loadReportsFromPeriod(this.date);
  }

  initializeValues() {
    this.totalPublisherDelivered = 0;
    this.totalPublishers = 0;
    this.totalAuxiliar = 0;
    this.totalAuxiliar30 = 0;
    this.totalAuxiliarRegular = 0;
    this.totalRegular = 0;
    this.totalEspecial = 0;
    this.totalDelivered = 0;

    this.totalReport = [];

    this.totalPublishersReport = [];
    this.totalAuxiliarReport = [];
    this.totalAuxiliar30Report = [];
    this.totalAuxiliarRegularReport = [];
    this.totalRegularReport = [];
    this.totalEspecialReport = [];

    this.dataReport = {
      Name: '',
      Pioneer: '',
      Colocations: 0,
      Video: 0,
      Hours: 0,
      Bethel: 0,
      Credit: 0,
      Returns: 0,
      Studies: 0,
      Obs: '',
      Status: '',
      Group: ''
    };

    this.totalsPublishers = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };

    this.totalsAuxiliar = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
    this.totalsAuxiliar30 = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
    this.totalsAuxiliarRegular = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
    this.totalsRegular = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
    this.totalsEspecial = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
    this.totals = {
      description: '',
      studies: 0,
      hours: 0,
      returns: 0,
      colocations: 0,
      obs: '',
      videos: 0,
      betelHours: 0,
      creditHours: 0
    };
  }

  loadReportsFromPeriod(report: IDate) {
    report.toDate = report.fromDate;
    this.datePdf = report.fromDate;
    console.log(
      'list loadReportsFromPeriod(): from ' +
        moment(report.fromDate).format('YYYY-MM-DD') +
        ' - to ' +
        moment(report.toDate).format('YYYY-MM-DD')
    );
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

    this.reportService
      .getReportPioneerByPeriod(fromDate, toDate, this.pioneerId)
      .subscribe(
        (reports: ServicoCampo[]) => {
          this.reports = reports;
          this.totalPublisher = this.reports.length;
          this.initializeValues();
          this.reports.forEach(element => {
            if (element.horas > 0) {
              this.totalPublisherDelivered = this.totalPublisherDelivered + 1;
            }
            this.totalizer(element);
          });

          if (this.totalsEspecial.description !== '') {
            this.totalReport.push([
              this.totalsEspecial.description,
              this.totalsEspecial.colocations,
              this.totalsEspecial.hours,
              this.totalsEspecial.returns,
              this.totalsEspecial.studies
            ]);
          }

          if (this.totalsRegular.description !== '') {
            this.totalReport.push([
              this.totalsRegular.description,
              this.totalsRegular.colocations,
              this.totalsRegular.hours,
              this.totalsRegular.returns,
              this.totalsRegular.studies
            ]);
          }

          if (this.totalsAuxiliarRegular.description !== '') {
            this.totalReport.push([
              this.totalsAuxiliarRegular.description,
              this.totalsAuxiliarRegular.colocations,
              this.totalsAuxiliarRegular.hours,
              this.totalsAuxiliarRegular.returns,
              this.totalsAuxiliarRegular.studies
            ]);
          }

          if (this.totalsAuxiliar.description !== '') {
            this.totalReport.push([
              this.totalsAuxiliar.description,
              this.totalsAuxiliar.colocations,
              this.totalsAuxiliar.hours,
              this.totalsAuxiliar.returns,
              this.totalsAuxiliar.studies
            ]);
          }

          if (this.totalsAuxiliar30.description !== '') {
            this.totalReport.push([
              this.totalsAuxiliar30.description,
              this.totalsAuxiliar30.colocations,
              this.totalsAuxiliar30.hours,
              this.totalsAuxiliar30.returns,
              this.totalsAuxiliar30.studies
            ]);
          }

          if (this.totalsPublishers.description !== '') {
            this.totalReport.push([
              this.totalsPublishers.description,
              this.totalsPublishers.colocations,
              this.totalsPublishers.hours,
              this.totalsPublishers.returns,
              this.totalsPublishers.studies
            ]);
          }

          console.log(this.totalReport);

          this.totals.description = 'Total';
          this.totals.colocations =
            this.totalsPublishers.colocations +
            this.totalsAuxiliar.colocations +
            this.totalsAuxiliar30.colocations +
            this.totalsAuxiliarRegular.colocations +
            this.totalsEspecial.colocations +
            this.totalsRegular.colocations;

          this.totals.videos =
            this.totalsPublishers.videos +
            this.totalsAuxiliar.videos +
            this.totalsAuxiliar30.videos +
            this.totalsAuxiliarRegular.videos +
            this.totalsEspecial.videos +
            this.totalsRegular.videos;

          this.totals.hours =
            this.totalsPublishers.hours +
            this.totalsPublishers.betelHours +
            this.totalsPublishers.creditHours +
            this.totalsAuxiliar.hours +
            this.totalsAuxiliar.betelHours +
            this.totalsAuxiliar.creditHours +
            this.totalsAuxiliar30.hours +
            this.totalsAuxiliar30.betelHours +
            this.totalsAuxiliar30.creditHours +
            this.totalsAuxiliarRegular.hours +
            this.totalsAuxiliarRegular.betelHours +
            this.totalsAuxiliarRegular.creditHours +
            this.totalsEspecial.hours +
            this.totalsEspecial.betelHours +
            this.totalsEspecial.creditHours +
            this.totalsRegular.hours +
            this.totalsRegular.betelHours +
            this.totalsRegular.creditHours;

          this.totals.betelHours =
            this.totalsPublishers.betelHours +
            this.totalsAuxiliar.betelHours +
            this.totalsAuxiliar30.betelHours +
            this.totalsAuxiliarRegular.betelHours +
            this.totalsEspecial.betelHours +
            this.totalsRegular.betelHours;

          if (this.totals.betelHours > 0) {
            this.totalReport.push(['Bethel', 0, this.totals.betelHours, 0, 0]);
          }

          this.totals.creditHours =
            this.totalsPublishers.creditHours +
            this.totalsAuxiliar.creditHours +
            this.totalsAuxiliar30.creditHours +
            this.totalsAuxiliarRegular.creditHours +
            this.totalsEspecial.creditHours +
            this.totalsRegular.creditHours;

          if (this.totals.creditHours > 0) {
            this.totalReport.push(['Credit', 0, this.totals.creditHours, 0, 0]);
          }

          this.totals.returns =
            this.totalsPublishers.returns +
            this.totalsAuxiliar.returns +
            this.totalsAuxiliar30.returns +
            this.totalsAuxiliarRegular.returns +
            this.totalsEspecial.returns +
            this.totalsRegular.returns;

          this.totals.studies =
            this.totalsPublishers.studies +
            this.totalsAuxiliar.studies +
            this.totalsAuxiliar30.studies +
            this.totalsAuxiliarRegular.studies +
            this.totalsEspecial.studies +
            this.totalsRegular.studies;

          this.totalDelivered =
            this.totalRegular +
            this.totalAuxiliar +
            this.totalAuxiliar30 +
            this.totalAuxiliarRegular +
            this.totalEspecial +
            this.totalPublishers;

          this.totalReport.push([
            'Total',
            { text: this.totals.colocations, color: 'red' },
            { text: this.totals.hours, color: 'red' },
            { text: this.totals.returns, color: 'red' },
            { text: this.totals.studies, color: 'red' }
          ]);
        },
        error => {
          this.alertifyService.error(error);
        }
      );
  }

  totalizer(element: any) {
    //   totalPublishersReport = [];
    // totalAuxiliarReport = [];
    // totalAuxiliar30Report = [];
    // totalAuxiliarRegularReport = [];
    // totalRegularReport = [];
    // totalEspecialReport = [];
    if (element.pioneiro.id === 1) {
      this.totalsPublishers.description = element.pioneiro.descricao;
      this.totalPublishers = this.totalPublishers + 1;
      this.totalsPublishers.colocations =
        this.totalsPublishers.colocations + element.publicacoes;
      this.totalsPublishers.studies =
        this.totalsPublishers.studies + element.estudos;
      this.totalsPublishers.hours = this.totalsPublishers.hours + element.horas;
      this.totalsPublishers.returns =
        this.totalsPublishers.returns + element.revisitas;
      this.totalsPublishers.obs =
        this.totalsPublishers.obs + element.observacao;
      this.totalsPublishers.videos =
        this.totalsPublishers.videos + element.videosMostrados;
      this.totalsPublishers.betelHours =
        this.totalsPublishers.betelHours + element.horasBetel;
      this.totalsPublishers.creditHours =
        this.totalsPublishers.creditHours + element.creditoHoras;
    } else if (element.pioneiro.id === 2) {
      this.totalAuxiliar30 = this.totalAuxiliar30 + 1;
      this.totalsAuxiliar30.description = element.pioneiro.descricao;
      this.totalsAuxiliar30.colocations =
        this.totalsAuxiliar30.colocations + element.publicacoes;
      this.totalsAuxiliar30.studies =
        this.totalsAuxiliar30.studies + element.estudos;
      this.totalsAuxiliar30.hours = this.totalsAuxiliar30.hours + element.horas;
      this.totalsAuxiliar30.returns =
        this.totalsAuxiliar30.returns + element.revisitas;
      this.totalsAuxiliar30.obs =
        this.totalsAuxiliar30.obs + element.observacao;
      this.totalsAuxiliar30.videos =
        this.totalsAuxiliar30.videos + element.videosMostrados;
      this.totalsAuxiliar30.betelHours =
        this.totalsAuxiliar30.betelHours + element.horasBetel;
      this.totalsAuxiliar30.creditHours =
        this.totalsAuxiliar30.creditHours + element.creditoHoras;
    } else if (element.pioneiro.id === 3) {
      this.totalAuxiliar = this.totalAuxiliar + 1;
      this.totalsAuxiliar.description = element.pioneiro.descricao;
      this.totalsAuxiliar.colocations =
        this.totalsAuxiliar.colocations + element.publicacoes;
      this.totalsAuxiliar.studies =
        this.totalsAuxiliar.studies + element.estudos;
      this.totalsAuxiliar.hours = this.totalsAuxiliar.hours + element.horas;
      this.totalsAuxiliar.returns =
        this.totalsAuxiliar.returns + element.revisitas;
      this.totalsAuxiliar.obs = this.totalsAuxiliar.obs + element.observacao;
      this.totalsAuxiliar.videos =
        this.totalsAuxiliar.videos + element.videosMostrados;
      this.totalsAuxiliar.betelHours =
        this.totalsAuxiliar.betelHours + element.horasBetel;
      this.totalsAuxiliar.creditHours =
        this.totalsAuxiliar.creditHours + element.creditoHoras;
    } else if (element.pioneiro.id === 4) {
      this.totalAuxiliarRegular = this.totalAuxiliarRegular + 1;
      this.totalsAuxiliarRegular.description = element.pioneiro.descricao;
      this.totalsAuxiliarRegular.colocations =
        this.totalsAuxiliarRegular.colocations + element.publicacoes;
      this.totalsAuxiliarRegular.studies =
        this.totalsAuxiliarRegular.studies + element.estudos;
      this.totalsAuxiliarRegular.hours =
        this.totalsAuxiliarRegular.hours + element.horas;
      this.totalsAuxiliarRegular.returns =
        this.totalsAuxiliarRegular.returns + element.revisitas;
      this.totalsAuxiliarRegular.obs =
        this.totalsAuxiliarRegular.obs + element.observacao;
      this.totalsAuxiliarRegular.videos =
        this.totalsAuxiliarRegular.videos + element.videosMostrados;
      this.totalsAuxiliarRegular.betelHours =
        this.totalsAuxiliarRegular.betelHours + element.horasBetel;
      this.totalsAuxiliarRegular.creditHours =
        this.totalsAuxiliarRegular.creditHours + element.creditoHoras;
    } else if (element.pioneiro.id === 5) {
      this.totalRegular = this.totalRegular + 1;
      this.totalsRegular.description = 'Regular';
      this.totalsRegular.colocations =
        this.totalsRegular.colocations + element.publicacoes;
      this.totalsRegular.studies = this.totalsRegular.studies + element.estudos;
      this.totalsRegular.hours = this.totalsRegular.hours + element.horas;
      this.totalsRegular.returns =
        this.totalsRegular.returns + element.revisitas;
      this.totalsRegular.obs = this.totalsRegular.obs + element.observacao;
      this.totalsRegular.videos =
        this.totalsRegular.videos + element.videosMostrados;
      this.totalsRegular.betelHours =
        this.totalsRegular.betelHours + element.horasBetel;
      this.totalsRegular.creditHours =
        this.totalsRegular.creditHours + element.creditoHoras;
    } else if (element.pioneiro.id === 6) {
      this.totalEspecial = this.totalEspecial + 1;
      this.totalsEspecial.description = element.pioneiro.descricao;
      this.totalsEspecial.colocations =
        this.totalsEspecial.colocations + element.publicacoes;
      this.totalsEspecial.studies =
        this.totalsEspecial.studies + element.estudos;
      this.totalsEspecial.hours = this.totalsEspecial.hours + element.horas;
      this.totalsEspecial.returns =
        this.totalsEspecial.returns + element.revisitas;
      this.totalsEspecial.obs = this.totalsEspecial.obs + element.observacao;
      this.totalsEspecial.videos =
        this.totalsEspecial.videos + element.videosMostrados;
      this.totalsEspecial.betelHours =
        this.totalsEspecial.betelHours + element.horasBetel;
      this.totalsEspecial.creditHours =
        this.totalsEspecial.creditHours + element.creditoHoras;
    }
  }

  generatePdf() {
    const docDefinition = {
      info: {
        title: 'CongregationFieldService',
        author: 'Renato Lima',
        subject: 'Congregation Field Service Report',
        keywords: 'Field Service Report',
      },
      pageSize: 'A4',
      pageMargins: [25, 80, 25, 25],
      header: [
        {
          text: 'Vitória English Congregation',
          style: 'header'
          // alignment: 'center'
        },
        {
          columns: [
            {text: '', style: 'subheader'},
            {text: 'Field Service Report', style: 'subheader'},
            {text: moment(Date.now()).format('MMM/DD/YYYY'), style: 'subsubheader'}
          ]
        },
        {
          text: moment(this.datePdf).format('MMM/YYYY'),
          style: 'subsubheader'
          // alignment: 'center'
        },
        {
          canvas: [
            {
              type: 'line',
              x1: 0,
              y1: 5,
              x2: 600,
              y2: 5,
              lineWidth: 0.2,
              style: 'subsubheader'
            }
          ],
          style: 'header'
        }
      ],
      footer: function(currentPage, pageCount) {
        return [
          {
            columns: [
              {
                text:
                  '\u00A9 ' +
                  2014 +
                  '-' +
                  moment(Date.now()).format('YYYY') +
                  ' : RTL-Systems',
                alignment: 'left',
                style: 'footer'
              },
              {
                text: currentPage.toString() + ' of ' + pageCount,
                alignment: 'right',
                style: 'footer'
              }
            ]
          }
        ];
      },

      content: [
        table(this.reports, [
          'Name',
          'Pioneer',
          'Colocations',
          'Video',
          'Hours',
          'Bethel',
          'Credit',
          'Returns',
          'Studies',
          'Status',
          'Group'
        ]),
        {
          text: 'Total of Congregation Field Service:',
          pageBreak: 'before',
          style: 'header'
        },
        {
          text: ' ',
          style: 'subheader'
        },
        tableSummarize(this.totalReport, [
          'Description',
          'Colocations',
          'Hours',
          'Returns',
          'Studies'
        ])
      ],

      styles: {
        header: {
          fontSize: 18,
          bold: true,
          alignment: 'center',
          margin: [0, 0, 0, 0],
          color: 'blue'
        },
        subheader: {
          fontSize: 12,
          alignment: 'center',
          bold: true,
          color: 'green'
        },
        subsubheader: {
          fontSize: 10,
          alignment: 'center',
          color: 'red',
          bold: true,
          margin: [0, 0, 0, 0]
        },
        superMargin: {
          margin: [5, 0, 5, 0],
          fontSize: 15
        },
        tableExample: {
          margin: [0, 5, 0, 15],
          fontSize: 10
        },
        tableHeader: {
          bold: true,
          fontSize: 13,
          color: 'black'
        },
        footer: {
          margin: [5, 0, 5, 0],
          fontSize: 8
        }
      }
    };

    function footer(currentPage, pageCount) {
      return currentPage.toString() + ' of ' + pageCount;
    }

    function table(data, columns) {
      return {
        style: 'tableExample',
        alignment: 'center',
        table: {
          headerRows: 1,
          widths: columnsWidths(columns),
          body: buildTableBody(data, columns)
        },
        layout: 'lightHorizontalLines',
        tableExample: {
          margin: [0, 5, 0, 15],
          fontSize: 8
        }
      };
    }

    function buildTableBody(data, columns) {
      const body = [];
      let dataReport: IFieldServiceReportPdf;
      const columnsR = [];
      body.push(columns);

      data.forEach(function(row) {
        const dataRow = [];

        columns.forEach(function(column) {
          dataReport = row;

          if (column === 'Name') {
            dataRow.push({
              text: row.publicador.nomeSobrenome,
              color: 'blue',
              alignment: 'left'
            });
          } else if (column === 'Pioneer') {
            dataRow.push(row.pioneiro.descricao);
          } else if (column === 'Colocations') {
            dataRow.push(row.publicacoes);
          } else if (column === 'Video') {
            dataRow.push(row.videosMostrados);
          } else if (column === 'Hours') {
            if (row.horas > 0) {
              dataRow.push({ text: row.horas, color: 'blue' });
            } else {
              dataRow.push({ text: row.horas, color: 'red' });
            }
          } else if (column === 'Bethel') {
            dataRow.push(row.horasBetel);
          } else if (column === 'Credit') {
            dataRow.push(row.creditoHoras);
          } else if (column === 'Returns') {
            dataRow.push(row.revisitas);
          } else if (column === 'Studies') {
            dataRow.push(row.estudos);
          } else if (column === 'Status') {
            dataRow.push(row.publicador.situacaoServicoCampo);
          } else if (column === 'Group') {
            dataRow.push(row.publicador.grupo.local);
          }
        });

        body.push(dataRow);
      });

      return body;
    }

    function tableSummarize(data, columns) {
      return {
        style: 'tableExample',
        alignment: 'center',
        table: {
          headerRows: 1,
          widths: columnsWidths(columns),
          body: buildTableSummarizeBody(data, columns)
        },
        layout: 'lightHorizontalLines',
        tableExample: {
          margin: [0, 5, 0, 15],
          fontSize: 8
        }
      };
    }

    function buildTableSummarizeBody(data, columns) {
      const body = [];
      let dataReport: IFieldServiceReportPdf;
      const columnsR = [];
      body.push(columns);

      data.forEach(function(row) {
        const dataRow = [];

        columns.forEach(function(column) {
          dataReport = row;

          if (column === 'Description') {
            dataRow.push({
              text: row[0],
              color: 'blue',
              alignment: 'left'
            });
          } else if (column === 'Colocations') {
            dataRow.push(row[1]);
          } else if (column === 'Hours') {
            if (row[2] > 0) {
              dataRow.push({ text: row[2], color: 'blue' });
            } else {
              dataRow.push({ text: row[2], color: 'red' });
            }
          } else if (column === 'Returns') {
            dataRow.push(row[3]);
          } else if (column === 'Studies') {
            dataRow.push(row[4]);
          }
        });
        console.log(dataRow);

        body.push(dataRow);
      });

      console.log(body);

      return body;
    }

    function columnsWidths(numberCols: any) {
      const width = [];
      // to cengralize all table
      width.push('*');
      for (let i = 0; i < numberCols.length - 2; i++) {
        width.push('auto');
      }
      width.push('*');
      return width;
    }

    // open the PDF in a new window .download('optionalName.pdf');
    // pdfMake.createPdf(docDefinition).open();

    // print the PDF
    // pdfMake.createPdf(docDefinition).print();

    // download the PDF
    pdfMake.createPdf(docDefinition).download('CongregationFieldservice.pdf');
  }
}
