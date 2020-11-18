import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistsPassengerComponent } from './exists-passenger.component';

describe('ExistsPassengerComponent', () => {
  let component: ExistsPassengerComponent;
  let fixture: ComponentFixture<ExistsPassengerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistsPassengerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistsPassengerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
