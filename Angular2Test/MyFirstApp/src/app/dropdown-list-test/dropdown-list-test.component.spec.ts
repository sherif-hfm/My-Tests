import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownListTestComponent } from './dropdown-list-test.component';

describe('DropdownListTestComponent', () => {
  let component: DropdownListTestComponent;
  let fixture: ComponentFixture<DropdownListTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropdownListTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropdownListTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
