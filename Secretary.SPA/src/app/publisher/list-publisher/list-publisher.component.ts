import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Publicador } from 'src/app/_models/Publicador';

@Component({
  selector: 'app-list-publisher',
  templateUrl: './list-publisher.component.html',
  styleUrls: ['./list-publisher.component.css']
})
export class ListPublisherComponent implements OnInit {
  title = 'Publishers';
  publishers: Publicador[];

  rows: any[] = [];
  temp = [];
  expanded: any = {};
  timeout: any;

  val: string;
  msg: string;

  constructor(
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loadPublishers();
  }


  loadPublishers() {
    this.route.data.subscribe(data => {
      this.publishers = data['publishers'];
      // cache our list
      this.temp = [...this.publishers];
      // push our inital complete list
      this.rows = this.publishers;
      this.msg = this.publishers.length + ' publisher(s) loaded!!';
      this.alertifyService.success(this.msg);
    });
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
