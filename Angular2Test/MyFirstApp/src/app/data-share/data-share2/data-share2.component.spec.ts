import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataShare2Component } from './data-share2.component';

describe('DataShare2Component', () => {
  let component: DataShare2Component;
  let fixture: ComponentFixture<DataShare2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataShare2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataShare2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
