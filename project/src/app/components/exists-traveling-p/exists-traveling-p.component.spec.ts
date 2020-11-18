import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistsTravelingPComponent } from './exists-traveling-p.component';

describe('ExistsTravelingPComponent', () => {
  let component: ExistsTravelingPComponent;
  let fixture: ComponentFixture<ExistsTravelingPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistsTravelingPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistsTravelingPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
