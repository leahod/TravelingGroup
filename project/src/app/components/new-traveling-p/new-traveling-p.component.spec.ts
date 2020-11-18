import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTravelingPComponent } from './new-traveling-p.component';

describe('NewTravelingPComponent', () => {
  let component: NewTravelingPComponent;
  let fixture: ComponentFixture<NewTravelingPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewTravelingPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewTravelingPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
