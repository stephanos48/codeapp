/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OpsComponent } from './ops.component';

describe('OpsComponent', () => {
  let component: OpsComponent;
  let fixture: ComponentFixture<OpsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
