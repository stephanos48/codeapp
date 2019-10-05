/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { IncinspectionComponent } from './incinspection.component';

describe('IncinspectionComponent', () => {
  let component: IncinspectionComponent;
  let fixture: ComponentFixture<IncinspectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncinspectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncinspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
