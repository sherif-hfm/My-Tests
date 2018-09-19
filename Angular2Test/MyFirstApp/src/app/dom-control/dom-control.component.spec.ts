import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DomControlComponent } from './dom-control.component';

describe('DomControlComponent', () => {
  let component: DomControlComponent;
  let fixture: ComponentFixture<DomControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DomControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DomControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
