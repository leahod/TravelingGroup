import { TestBed } from '@angular/core/testing';

import { PassengerServiceService } from './passenger-service.service';

describe('PassengerServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PassengerServiceService = TestBed.get(PassengerServiceService);
    expect(service).toBeTruthy();
  });
});
