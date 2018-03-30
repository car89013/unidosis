import { TestBed, inject } from '@angular/core/testing';

import { MedicosService } from './medicos.service';

describe('MedicosService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MedicosService]
    });
  });

  it('should be created', inject([MedicosService], (service: MedicosService) => {
    expect(service).toBeTruthy();
  }));
});
