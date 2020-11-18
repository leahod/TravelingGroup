import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTravelingDComponent } from './new-traveling-d.component';

describe('NewTravelingDComponent', () => {
  let component: NewTravelingDComponent;
  let fixture: ComponentFixture<NewTravelingDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewTravelingDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewTravelingDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
