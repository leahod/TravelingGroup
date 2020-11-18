import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmDriverComponent } from './confirm-driver.component';

describe('ConfirmDriverComponent', () => {
  let component: ConfirmDriverComponent;
  let fixture: ComponentFixture<ConfirmDriverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmDriverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
