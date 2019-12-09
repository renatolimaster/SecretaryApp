import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Congregacao } from 'src/app/_models/Congregacao';

@Component( {
  selector: 'app-list-congregation',
  templateUrl: './list-congregation.component.html',
  styleUrls: [ './list-congregation.component.css' ]
} )
export class ListCongregationComponent implements OnInit
{
  title = 'Congregation';
  congregations: Congregacao[];

  rows: any[] = [];
  temp = [];
  expanded: any = {};
  timeout: any;

  val: string;
  msg: string;

  constructor (
    private alertifyService: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit ()
  {
    this.loadCongregations();
  }

  loadCongregations ()
  {
    this.route.data.subscribe( data =>
    {
      this.congregations = data[ 'congregation' ];
      // cache our list
      this.temp = [ ...this.congregations ];
      // push our initial complete list
      this.rows = this.congregations;
      // console.log( 'Congregations', this.congregations );
      this.msg = this.congregations.length + ' congregation(s) loaded!!';
      this.alertifyService.success( this.msg );
    } );
  }

  onPage ( event )
  {
    clearTimeout( this.timeout );
    this.timeout = setTimeout( () =>
    {
      console.log( 'paged!', event );
    }, 100 );
  }

  updateFilter ( event )
  {
    this.msg = '';
    const val = event.target.value.toLowerCase();
    this.val = val;

    // filter our data: from Row Detail Template - myDetailRow
    const temp = this.temp.filter( function ( d )
    {
      return d.nome.toLowerCase().indexOf( val ) !== -1 || !val;
    } );

    // update the rows
    this.rows = temp;
    // Whenever the filter changes, always go back to the first page
    // this.table.offset = 0;
  }

  toggleExpandRow ( row )
  {
    console.log( 'Toggled Expand Row!', row );
    // this.table.rowDetail.toggleExpandRow(row);
  }

  onDetailToggle ( event )
  {
    console.log( 'Detail Toggled', event );
  }

}
