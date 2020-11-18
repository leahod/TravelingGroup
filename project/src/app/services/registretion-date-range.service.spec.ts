import { TestBed } from '@angular/core/testing';

import { RegistretionDateRangeService } from './registretion-date-range.service';

describe('RegistretionDateRangeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RegistretionDateRangeService = TestBed.get(RegistretionDateRangeService);
    expect(service).toBeTruthy();
  });
});
