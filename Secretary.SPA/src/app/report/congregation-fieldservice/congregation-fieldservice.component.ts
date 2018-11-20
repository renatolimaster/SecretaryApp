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
import { element } from 'protractor';

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
  dataReport: IFieldServiceReportPdf;
  datePdf: Date;

  totalReport = [];

  totalPublishersReport = [];
  totalAuxiliarReport = [];
  totalAuxiliar30Report = [];
  totalAuxiliarRegularReport = [];
  totalRegularReport = [];
  totalEspecialReport = [];

  pioneerId = 0;
  totalPublisher = 0;

  // new conception
  reportRegular = [];
  reportNao = [];
  reportLine: IFieldServiceReportPdf[];
  reportLineGeral: IFieldServiceReportPdf[];
  descricao = '';
  group = '';
  hours = 0;
  hoursBethel = 0;
  creditHours = 0;
  colocations = 0;
  videos = 0;
  returns = 0;
  studies = 0;
  publisherType = [];
  msg: string;
  //

  // COUNTER
  counter1 = 0;
  counter2 = 0;
  counter3 = 0;
  counter4 = 0;
  counter5 = 0;
  counter6 = 0;
  counterTotal = 0;
  //

  myForm: FormGroup;

  constructor(
    private dateTimeExtensions: DateTimeExtensions,
    private reportService: ReportService,
    private alertifyService: AlertifyService
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
      check: false
    };

    if (this.date.check) {
      this.publisherType = [
        'Especial',
        'Regular',
        'Auxiliar Regular',
        'Auxiliar',
        'Auxiliar 30 horas',
        'Não'
      ];
    } else {
      this.publisherType = ['Vitória', 'Vila Velha', 'Serra'];
    }

    this.initializeValues();

    this.loadReportsFromPeriod(this.date);
  }

  initializeValues() {
    // new conception
    this.reportRegular = [];
    this.reportLine = [];
    this.reportLineGeral = [];
    //

    this.totalReport = [];

    this.dataReport = {
      Counter: 0,
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
  }

  loadReportsFromPeriod(report: IDate) {
    report.toDate = report.fromDate;
    this.datePdf = report.fromDate;

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

    if (this.date.check) {
      this.publisherType = ['Vitória', 'Vila Velha', 'Serra'];
    } else {
      this.publisherType = [
        'Especial',
        'Regular',
        'Auxiliar Regular',
        'Auxiliar',
        'Auxiliar 30 horas',
        'Não'
      ];
    }

    this.reportService
      .getReportPioneerByPeriod(fromDate, toDate, this.pioneerId)
      .subscribe(
        (reports: ServicoCampo[]) => {
          this.reports = reports;
          this.totalPublisher = this.reports.length;
          this.initializeValues();
          this.setReportLine(this.reports, this.publisherType, report.check);
          this.msg = this.reports.length + ' report(s) loaded!!';
          this.alertifyService.success(this.msg);
        },
        error => {
          this.alertifyService.error(error);
        }
      );
  }

  setReportLine(report: ServicoCampo[], publisherType: any, group: boolean) {
    this.descricao = '';
    this.group = '';
    this.hours = 0;
    this.hoursBethel = 0;
    this.creditHours = 0;
    this.colocations = 0;
    this.videos = 0;
    this.returns = 0;
    this.studies = 0;

    // COUNTER
    this.counter1 = 0;
    this.counter2 = 0;
    this.counter3 = 0;
    this.counter4 = 0;
    this.counter5 = 0;
    this.counter6 = 0;
    this.counterTotal = 0;

    if (group) {
      publisherType.forEach(itemPublisherType => {
        this.reportRegular = report.filter(
          (service: ServicoCampo) =>
            service.publicador.grupo.local === itemPublisherType
        );

        if (this.reportRegular.length > 0) {
          this.descricao = '';
          this.group = '';
          this.hours = 0;
          this.hoursBethel = 0;
          this.creditHours = 0;
          this.colocations = 0;
          this.videos = 0;
          this.returns = 0;
          this.studies = 0;
          this.counter5 = 0;

          this.reportRegular.forEach(item => {
            if (
              item.horas > 0 ||
              item.horasBetel > 0 ||
              item.creditoHoras > 0
            ) {
              this.counter5++;
            }
            this.reportLine.push({
              Counter: this.counter5,
              Name: item.publicador.nome,
              Pioneer: item.pioneiro.descricao,
              Colocations: item.publicacoes,
              Hours: item.horas,
              Bethel: item.horasBetel,
              Credit: item.creditoHoras,
              Video: item.videosMostrados,
              Returns: item.revisitas,
              Studies: item.estudos,
              Obs: item.observacao,
              Status: item.publicador.situacaoServicoCampo,
              Group: item.publicador.grupo.local
            });
            this.descricao = item.pioneiro.descricao;
            this.colocations = this.colocations + item.publicacoes;

            this.hours =
              this.hours + item.horas + item.horasBetel + item.creditoHoras;

            console.log(
              'Horas fora: ' +
                item.publicador.nome +
                ' - ' +
                this.hours +
                ' - ' +
                this.hoursBethel +
                ' - ' +
                this.creditHours
            );

            if (this.hoursBethel > 0 || this.creditHours > 0) {
              console.log(
                'Horas dentro: ' +
                  item.publicador.nome +
                  ' - ' +
                  this.hours +
                  ' - ' +
                  this.hoursBethel +
                  ' - ' +
                  this.creditHours
              );
              if (this.hours > 70) {
                this.hours = 70;
              }
            }

            this.hoursBethel = this.hoursBethel + item.horasBetel;
            this.creditHours = this.creditHours + item.creditoHoras;
            this.videos = this.videos + item.videosMostrados;
            this.returns = this.returns + item.revisitas;
            this.studies = this.studies + item.estudos;
            this.group = item.publicador.grupo.local;
          });
          this.reportLine.push({
            Counter: this.counter5,
            Name: 'Total',
            Pioneer: this.group,
            Colocations: this.colocations,
            Hours: this.hours,
            Bethel: this.hoursBethel,
            Credit: this.creditHours,
            Video: this.videos,
            Returns: this.returns,
            Studies: this.studies,
            Obs: ' ',
            Status: ' ',
            Group: ' '
          });
        }
        // FIM ESPECIAL
      });
    } else {
      publisherType.forEach(itemPublisherType => {
        this.reportRegular = report.filter(
          (service: ServicoCampo) =>
            service.pioneiro.descricao === itemPublisherType
        );

        if (this.reportRegular.length > 0) {
          this.descricao = '';
          this.group = '';
          this.hours = 0;
          this.hoursBethel = 0;
          this.creditHours = 0;
          this.colocations = 0;
          this.videos = 0;
          this.returns = 0;
          this.studies = 0;
          this.counter5 = 0;

          this.reportRegular.forEach(item => {
            if (
              item.horas > 0 ||
              item.horasBetel > 0 ||
              item.creditoHoras > 0
            ) {
              this.counter5++;
            }
            this.reportLine.push({
              Counter: this.counter5,
              Name: item.publicador.nome,
              Pioneer: item.pioneiro.descricao,
              Colocations: item.publicacoes,
              Hours: item.horas,
              Bethel: item.horasBetel,
              Credit: item.creditoHoras,
              Video: item.videosMostrados,
              Returns: item.revisitas,
              Studies: item.estudos,
              Obs: item.observacao,
              Status: item.publicador.situacaoServicoCampo,
              Group: item.publicador.grupo.local
            });
            this.descricao = item.pioneiro.descricao;
            this.group = item.publicador.grupo.local;
            this.colocations = this.colocations + item.publicacoes;

            this.hours =
              this.hours + item.horas + item.horasBetel + item.creditoHoras;

            this.hoursBethel = this.hoursBethel + item.horasBetel;
            this.creditHours = this.creditHours + item.creditoHoras;
            this.videos = this.videos + item.videosMostrados;
            this.returns = this.returns + item.revisitas;
            this.studies = this.studies + item.estudos;
          });
          this.reportLine.push({
            Counter: this.counter5,
            Name: 'Total',
            Pioneer: this.descricao,
            Colocations: this.colocations,
            Hours: this.hours,
            Bethel: this.hoursBethel,
            Credit: this.creditHours,
            Video: this.videos,
            Returns: this.returns,
            Studies: this.studies,
            Obs: ' ',
            Status: ' ',
            Group: ' '
          });
        }
        // FIM ESPECIAL
      });
    }

    // finalizacao

    this.reportLineGeral = this.reportLine.filter(
      (service: IFieldServiceReportPdf) => service.Name === 'Total'
    );

    let totalColocations = 0;
    let totalVideos = 0;
    let totalHours = 0;
    let totalReturns = 0;
    let totalStudies = 0;
    let totalBethel = 0;
    let totalCredit = 0;
    this.counterTotal = 0;

    this.reportLineGeral.forEach(item => {
      (this.counterTotal = this.counterTotal + item.Counter),
        (totalColocations = totalColocations + item.Colocations);
      totalVideos = totalVideos + item.Video;
      totalHours = totalHours + item.Hours;
      totalReturns = totalReturns + item.Returns;
      totalStudies = totalStudies + item.Studies;
      totalBethel = totalBethel + item.Bethel;
      totalCredit = totalCredit + item.Credit;
    });

    this.reportLineGeral.push({
      Counter: this.counterTotal,
      Name: 'Geral',
      Pioneer: 'Geral',
      Colocations: totalColocations,
      Hours: totalHours,
      Bethel: totalBethel,
      Credit: totalCredit,
      Video: totalVideos,
      Returns: totalReturns,
      Studies: totalStudies,
      Obs: ' ',
      Status: ' ',
      Group: ' '
    });
  }

  generatePdf() {
    const docDefinition = {
      info: {
        title: 'CongregationFieldService',
        author: 'Renato Lima',
        subject: 'Congregation Field Service Report',
        keywords: 'Field Service Report'
      },
      pageSize: 'A4',
      pageMargins: [15, 80, 15, 15],
      header: [
        {
          text: 'Vitória English Congregation',
          style: 'header'
          // alignment: 'center'
        },
        {
          columns: [
            { text: '', style: 'subheader' },
            { text: 'Field Service Report', style: 'subheader' },
            {
              text: moment(Date.now()).format('MMM/DD/YYYY'),
              style: 'subsubheader'
            }
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
        table(this.reportLine, [
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
        tableSummarize(this.reportLineGeral, [
          'Description',
          'Colocations',
          'Hours',
          'Returns',
          'Studies'
        ])
      ],

      styles: {
        header: {
          fontSize: 16,
          bold: true,
          alignment: 'center',
          margin: [0, 0, 0, 0],
          color: 'blue'
        },
        totalHeader: {
          fontSize: 14,
          bold: true,
          alignment: 'center',
          margin: [0, 0, 0, 0],
          color: 'red'
        },
        subTotalHeader: {
          fontSize: 12,
          bold: true,
          alignment: 'center',
          margin: [0, 0, 0, 0],
          color: 'red'
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

          if (row.Name === 'Total') {
            if (column === 'Name') {
              dataRow.push({
                text: row.Name + '(' + row.Counter + ')',
                color: 'red',
                alignment: 'left',
                style: 'subTotalHeader'
              });
            } else if (column === 'Pioneer') {
              dataRow.push({ text: row.Pioneer, style: 'subTotalHeader' });
            } else if (column === 'Colocations') {
              dataRow.push({ text: row.Colocations, style: 'subTotalHeader' });
            } else if (column === 'Video') {
              dataRow.push({ text: row.Video, style: 'subTotalHeader' });
            } else if (column === 'Hours') {
              dataRow.push({ text: row.Hours, style: 'subTotalHeader' });
            } else if (column === 'Bethel') {
              dataRow.push({ text: row.Bethel, style: 'subTotalHeader' });
            } else if (column === 'Credit') {
              dataRow.push({ text: row.Credit, style: 'subTotalHeader' });
            } else if (column === 'Returns') {
              dataRow.push({ text: row.Returns, style: 'subTotalHeader' });
            } else if (column === 'Studies') {
              dataRow.push({ text: row.Studies, style: 'subTotalHeader' });
            } else if (column === 'Status') {
              dataRow.push({ text: row.Status, style: 'subTotalHeader' });
            } else if (column === 'Group') {
              dataRow.push({ text: row.Group, style: 'subTotalHeader' });
            }
          } else {
            if (column === 'Name') {
              dataRow.push({
                text:
                  row.Name.split(' ')[0] +
                  ' ' +
                  row.Name.split(' ')[row.Name.split(' ').length - 1],
                color: 'blue',
                alignment: 'left'
              });
            } else if (column === 'Pioneer') {
              dataRow.push(row.Pioneer);
            } else if (column === 'Colocations') {
              dataRow.push(row.Colocations);
            } else if (column === 'Video') {
              dataRow.push(row.Video);
            } else if (column === 'Hours') {
              if (row.Hours > 0) {
                dataRow.push({ text: row.Hours, color: 'blue' });
              } else {
                dataRow.push({ text: row.Hours, color: 'red' });
              }
            } else if (column === 'Bethel') {
              dataRow.push(row.Bethel);
            } else if (column === 'Credit') {
              dataRow.push(row.Credit);
            } else if (column === 'Returns') {
              dataRow.push(row.Returns);
            } else if (column === 'Studies') {
              dataRow.push(row.Studies);
            } else if (column === 'Status') {
              dataRow.push(row.Status);
            } else if (column === 'Group') {
              dataRow.push(row.Group);
            }
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
      body.push(columns);

      data.forEach(function(row) {
        const dataRow = [];

        columns.forEach(function(column) {
          dataReport = row;

          if (row.Name === 'Total') {
            if (column === 'Description') {
              dataRow.push({
                text: row.Pioneer + '(' + row.Counter + ')',
                color: 'blue',
                alignment: 'left'
              });
            } else if (column === 'Colocations') {
              dataRow.push(row.Colocations);
            } else if (column === 'Hours') {
              if (row.Hours > 0) {
                dataRow.push({ text: row.Hours, color: 'blue' });
              } else {
                dataRow.push({ text: row.Hours, color: 'red' });
              }
            } else if (column === 'Returns') {
              dataRow.push(row.Returns);
            } else if (column === 'Studies') {
              dataRow.push(row.Studies);
            }
          } else {
            if (column === 'Description') {
              dataRow.push({
                text: row.Pioneer,
                alignment: 'left',
                style: 'totalHeader'
              });
            } else if (column === 'Colocations') {
              dataRow.push({
                text: row.Colocations,
                style: 'totalHeader'
              });
            } else if (column === 'Hours') {
              if (row.Hours > 0) {
                dataRow.push({
                  text: row.Hours,
                  style: 'totalHeader'
                });
              } else {
                dataRow.push({
                  text: row.Hours,
                  style: 'totalHeader'
                });
              }
            } else if (column === 'Returns') {
              dataRow.push({ text: row.Returns, style: 'totalHeader' });
            } else if (column === 'Studies') {
              dataRow.push({ text: row.Studies, style: 'totalHeader' });
            }
          }
        });

        body.push(dataRow);
      });

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
    pdfMake.createPdf(docDefinition).open();

    // print the PDF
    // pdfMake.createPdf(docDefinition).print();

    // download the PDF
    // const date = moment(this.datePdf).format('MMM-YYYY');
    // pdfMake.createPdf(docDefinition).download('CongregationFieldservice_' + date + '.pdf');
  }
}
