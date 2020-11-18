import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsTravelingPComponent } from './details-traveling-p.component';

describe('DetailsTravelingPComponent', () => {
  let component: DetailsTravelingPComponent;
  let fixture: ComponentFixture<DetailsTravelingPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsTravelingPComponent ]
    })
    .compileComponents();
  })); 

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsTravelingPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
