/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MyEtradeComponent } from './my-etrade.component';

describe('MyEtradeComponent', () => {
  let component: MyEtradeComponent;
  let fixture: ComponentFixture<MyEtradeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyEtradeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyEtradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
