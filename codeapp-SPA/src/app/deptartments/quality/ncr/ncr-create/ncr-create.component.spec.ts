/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NcrCreateComponent } from './ncr-create.component';

describe('NcrCreateComponent', () => {
  let component: NcrCreateComponent;
  let fixture: ComponentFixture<NcrCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NcrCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NcrCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
