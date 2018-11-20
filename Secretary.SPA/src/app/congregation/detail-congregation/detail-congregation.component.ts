import { Component, OnInit } from '@angular/core';
import { Congregacao } from 'src/app/_models/Congregacao';

@Component({
  selector: 'app-detail-congregation',
  templateUrl: './detail-congregation.component.html',
  styleUrls: ['./detail-congregation.component.css']
})
export class DetailCongregationComponent implements OnInit {
  title = 'Congregation';
  subTitles = 'Details';
  congregation: Congregacao;
  del: any;

  constructor() { }

  ngOnInit() {
  }

}
