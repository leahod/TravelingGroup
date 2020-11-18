import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCardDetailsComponent } from './edit-card-details.component';

describe('EditCardDetailsComponent', () => {
  let component: EditCardDetailsComponent;
  let fixture: ComponentFixture<EditCardDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCardDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCardDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
