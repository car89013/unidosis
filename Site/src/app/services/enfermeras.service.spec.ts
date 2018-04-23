import { TestBed, inject } from '@angular/core/testing';

import { EnfermerasService } from './enfermeras.service';

describe('EnfermerasService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EnfermerasService]
    });
  });

  it('should be created', inject([EnfermerasService], (service: EnfermerasService) => {
    expect(service).toBeTruthy();
  }));
});
