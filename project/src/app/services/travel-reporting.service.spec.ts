import { TestBed } from '@angular/core/testing';

import { TravelReportingService } from './travel-reporting.service';

describe('TravelReportingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TravelReportingService = TestBed.get(TravelReportingService);
    expect(service).toBeTruthy();
  });
});
