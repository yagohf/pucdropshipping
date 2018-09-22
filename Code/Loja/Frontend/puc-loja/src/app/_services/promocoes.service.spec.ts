import { TestBed } from '@angular/core/testing';

import { PromocoesService } from './promocoes.service';

describe('PromocoesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PromocoesService = TestBed.get(PromocoesService);
    expect(service).toBeTruthy();
  });
});
