import { TestBed } from '@angular/core/testing';

import { PropagandasService } from './propagandas.service';

describe('PropagandasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropagandasService = TestBed.get(PropagandasService);
    expect(service).toBeTruthy();
  });
});
