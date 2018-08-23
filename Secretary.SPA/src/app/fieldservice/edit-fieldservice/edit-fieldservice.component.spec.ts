/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditFieldserviceComponent } from './edit-fieldservice.component';

describe('EditFieldserviceComponent', () => {
  let component: EditFieldserviceComponent;
  let fixture: ComponentFixture<EditFieldserviceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditFieldserviceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditFieldserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
