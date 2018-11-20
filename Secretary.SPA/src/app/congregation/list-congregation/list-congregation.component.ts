import { Component, OnInit } from '@angular/core';
import { DateTimeExtensions } from 'src/app/_services/DateTimeExtensions';
import { ReportService } from 'src/app/_services/report.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { CongregationService } from 'src/app/_services/congregation.service';
import { Congregacao } from 'src/app/_models/Congregacao';
import { element } from 'protractor';

@Component({
  selector: 'app-list-congregation',
  templateUrl: './list-congregation.component.html',
  styleUrls: ['./list-congregation.component.css']
})
export class ListCongregationComponent implements OnInit {
  title = 'Congregation';
  congregations: Congregacao[];

  rows: any[] = [];
  temp = [];
  expanded: any = {};
  timeout: any;

  val: string;
  msg: string;

  constructor(
    private dateTimeExtensions: DateTimeExtensions,
    private congregationService: CongregationService,
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loadCongregations();
  }

  loadCongregations() {
    this.congregationService.getCongregations().subscribe(
      (congregations: Congregacao[]) => {
        this.congregations = congregations;
        // cache our list
        this.temp = [...congregations];
        // push our inital complete list
        this.rows = congregations;
        this.congregations.forEach(item => {
          console.log('Congre: ' + item.nome + ' - ' + item.coordenador + ' - ' + item.estado.descricao);
        });
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
    this.msg = '';
    const val = event.target.value.toLowerCase();
    this.val = val;

    // filter our data: from Row Detail Template - myDetailRow
    const temp = this.temp.filter(function(d) {
      return d.nome.toLowerCase().indexOf(val) !== -1 || !val;
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
