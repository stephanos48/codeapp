/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NcrModalComponent } from './ncr-modal.component';

describe('NcrModalComponent', () => {
  let component: NcrModalComponent;
  let fixture: ComponentFixture<NcrModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NcrModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NcrModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
