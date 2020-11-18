import { TestBed } from '@angular/core/testing';

import { TravelingPassengerService } from './traveling-passenger.service';

describe('TravelingPassengerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TravelingPassengerService = TestBed.get(TravelingPassengerService);
    expect(service).toBeTruthy();
  });
});
