import { TestBed } from '@angular/core/testing';

import { CarrinhoService } from './carrinho.service';

describe('CarrinhoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CarrinhoService = TestBed.get(CarrinhoService);
    expect(service).toBeTruthy();
  });
});
