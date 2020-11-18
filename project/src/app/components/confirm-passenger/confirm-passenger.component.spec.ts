import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmPassengerComponent } from './confirm-passenger.component';

describe('ConfirmPassengerComponent', () => {
  let component: ConfirmPassengerComponent;
  let fixture: ComponentFixture<ConfirmPassengerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmPassengerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmPassengerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
