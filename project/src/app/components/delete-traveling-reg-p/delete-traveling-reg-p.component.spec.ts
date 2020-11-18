import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTravelingRegPComponent } from './delete-traveling-reg-p.component';

describe('DeleteTravelingRegPComponent', () => {
  let component: DeleteTravelingRegPComponent;
  let fixture: ComponentFixture<DeleteTravelingRegPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteTravelingRegPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTravelingRegPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
