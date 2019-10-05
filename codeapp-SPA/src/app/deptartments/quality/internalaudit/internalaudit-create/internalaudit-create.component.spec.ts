/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InternalauditCreateComponent } from './internalaudit-create.component';

describe('InternalauditCreateComponent', () => {
  let component: InternalauditCreateComponent;
  let fixture: ComponentFixture<InternalauditCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalauditCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalauditCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
