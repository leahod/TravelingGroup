import { TestBed } from '@angular/core/testing';

import { StatisticsServiceService } from './statistics-service.service';

describe('StatisticsServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StatisticsServiceService = TestBed.get(StatisticsServiceService);
    expect(service).toBeTruthy();
  });
});
