import { TestBed } from '@angular/core/testing';

import { CategoriasService } from './categorias.service';

describe('CategoriasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CategoriasService = TestBed.get(CategoriasService);
    expect(service).toBeTruthy();
  });
});
