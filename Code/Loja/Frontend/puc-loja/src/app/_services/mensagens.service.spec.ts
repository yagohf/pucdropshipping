import { TestBed } from '@angular/core/testing';

import { MensagensService } from './mensagens.service';

describe('MensagensService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MensagensService = TestBed.get(MensagensService);
    expect(service).toBeTruthy();
  });
});
