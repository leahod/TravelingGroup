import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistsDriverComponent } from './exists-driver.component';

describe('ExistsDriverComponent', () => {
  let component: ExistsDriverComponent;
  let fixture: ComponentFixture<ExistsDriverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistsDriverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistsDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
