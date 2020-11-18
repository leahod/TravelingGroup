import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistsTravelingDComponent } from './exists-traveling-d.component';

describe('ExistsTravelingDComponent', () => {
  let component: ExistsTravelingDComponent;
  let fixture: ComponentFixture<ExistsTravelingDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistsTravelingDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistsTravelingDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
