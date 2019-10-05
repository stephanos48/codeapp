/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InternalauditEditComponent } from './internalaudit-edit.component';

describe('InternalauditEditComponent', () => {
  let component: InternalauditEditComponent;
  let fixture: ComponentFixture<InternalauditEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalauditEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalauditEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
