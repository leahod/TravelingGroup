import { TestBed } from '@angular/core/testing';

import { TravelingDriverService } from './traveling-driver.service';

describe('TravelingDriverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TravelingDriverService = TestBed.get(TravelingDriverService);
    expect(service).toBeTruthy();
  });
});
