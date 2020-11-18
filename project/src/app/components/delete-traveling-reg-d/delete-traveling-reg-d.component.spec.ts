import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTravelingRegDComponent } from './delete-traveling-reg-d.component';

describe('DeleteTravelingRegDComponent', () => {
  let component: DeleteTravelingRegDComponent;
  let fixture: ComponentFixture<DeleteTravelingRegDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteTravelingRegDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTravelingRegDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
