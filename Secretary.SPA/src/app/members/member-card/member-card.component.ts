import { Component, OnInit, Input } from '@angular/core';
import { Usuario } from '../../_models/Usuario';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() usuario: Usuario;

  constructor() {}

  ngOnInit() {

  }
}
