import { TestBed } from '@angular/core/testing';

import { PathologieService } from './pathologie.service';

describe('PathologieService', () => {
  let service: PathologieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PathologieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
