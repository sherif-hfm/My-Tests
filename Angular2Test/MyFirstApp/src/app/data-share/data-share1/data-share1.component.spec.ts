import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataShare1Component } from './data-share1.component';

describe('DataShare1Component', () => {
  let component: DataShare1Component;
  let fixture: ComponentFixture<DataShare1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataShare1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataShare1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
