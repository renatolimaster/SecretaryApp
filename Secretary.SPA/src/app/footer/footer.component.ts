import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  msg: any;

  constructor() { }

  ngOnInit() {
    const age = new Date();
    this.msg = 2014 + '-' + age.getFullYear();
  }

}
