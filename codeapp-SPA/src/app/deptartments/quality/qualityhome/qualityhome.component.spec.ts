/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { QualityhomeComponent } from './qualityhome.component';

describe('QualityhomeComponent', () => {
  let component: QualityhomeComponent;
  let fixture: ComponentFixture<QualityhomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QualityhomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QualityhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
