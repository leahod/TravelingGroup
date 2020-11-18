import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistsUserComponent } from './exists-user.component';

describe('ExistsUserComponent', () => {
  let component: ExistsUserComponent;
  let fixture: ComponentFixture<ExistsUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistsUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistsUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
