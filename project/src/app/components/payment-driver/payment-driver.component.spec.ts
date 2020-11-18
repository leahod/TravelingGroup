import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDriverComponent } from './payment-driver.component';

describe('PaymentDriverComponent', () => {
  let component: PaymentDriverComponent;
  let fixture: ComponentFixture<PaymentDriverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentDriverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
