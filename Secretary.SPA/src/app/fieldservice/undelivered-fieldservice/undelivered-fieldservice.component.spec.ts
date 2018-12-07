/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UndeliveredFieldserviceComponent } from './undelivered-fieldservice.component';

describe('UndeliveredFieldserviceComponent', () => {
  let component: UndeliveredFieldserviceComponent;
  let fixture: ComponentFixture<UndeliveredFieldserviceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UndeliveredFieldserviceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UndeliveredFieldserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
