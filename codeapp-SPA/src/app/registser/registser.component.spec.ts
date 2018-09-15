/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RegistserComponent } from './registser.component';

describe('RegistserComponent', () => {
  let component: RegistserComponent;
  let fixture: ComponentFixture<RegistserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
