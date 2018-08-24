import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';

@Component({
  selector: 'app-list-fieldservice',
  templateUrl: './list-fieldservice.component.html',
  styleUrls: ['./list-fieldservice.component.css']
})
export class ListFieldserviceComponent implements OnInit {
  title = 'Field Service';
  reports: ServicoCampo[];

  rows: any[] = [];
  temp = [];
  expanded: any = {};
  timeout: any;

  constructor(
    private reportService: ReportService,
    private alertifyService: AlertifyService
  ) { }

  ngOnInit() {
    this.loadReports();
  }


  loadReports() {
    console.log('here');
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
