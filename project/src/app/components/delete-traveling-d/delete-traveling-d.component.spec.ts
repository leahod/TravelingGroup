import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTravelingDComponent } from './delete-traveling-d.component';

describe('DeleteTravelingDComponent', () => {
  let component: DeleteTravelingDComponent;
  let fixture: ComponentFixture<DeleteTravelingDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteTravelingDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTravelingDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
