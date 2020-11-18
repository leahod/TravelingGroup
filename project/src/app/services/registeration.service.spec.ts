import { TestBed } from '@angular/core/testing';

import { RegisterationService } from './registeration.service';

describe('RegisterationService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RegisterationService = TestBed.get(RegisterationService);
    expect(service).toBeTruthy();
  });
});
