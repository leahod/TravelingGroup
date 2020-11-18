import { TestBed } from '@angular/core/testing';

import { TravelingServiceService } from './traveling-service.service';

describe('TravelingServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TravelingServiceService = TestBed.get(TravelingServiceService);
    expect(service).toBeTruthy();
  });
});
