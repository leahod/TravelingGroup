import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuitableDriversComponent } from './suitable-drivers.component';

describe('SuitableDriversComponent', () => {
  let component: SuitableDriversComponent;
  let fixture: ComponentFixture<SuitableDriversComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuitableDriversComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuitableDriversComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
