/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InternalauditModalComponent } from './internalaudit-modal.component';

describe('InternalauditModalComponent', () => {
  let component: InternalauditModalComponent;
  let fixture: ComponentFixture<InternalauditModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalauditModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalauditModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
