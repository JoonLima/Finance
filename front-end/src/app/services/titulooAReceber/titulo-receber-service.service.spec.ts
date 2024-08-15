import { TestBed } from '@angular/core/testing';

import { TituloReceberServiceService } from './titulo-receber-service.service';

describe('TituloReceberServiceService', () => {
  let service: TituloReceberServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TituloReceberServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
