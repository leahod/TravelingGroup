import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelingRangeComponent } from './traveling-range.component';

describe('TravelingRangeComponent', () => {
  let component: TravelingRangeComponent;
  let fixture: ComponentFixture<TravelingRangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TravelingRangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelingRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
