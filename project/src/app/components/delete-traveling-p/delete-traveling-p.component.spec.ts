import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTravelingPComponent } from './delete-traveling-p.component';

describe('DeleteTravelingPComponent', () => {
  let component: DeleteTravelingPComponent;
  let fixture: ComponentFixture<DeleteTravelingPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteTravelingPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTravelingPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
