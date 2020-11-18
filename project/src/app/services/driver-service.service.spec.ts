import { TestBed } from '@angular/core/testing';

import { DriverServiceService } from './driver-service.service';

describe('DriverServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DriverServiceService = TestBed.get(DriverServiceService);
    expect(service).toBeTruthy();
  });
});
