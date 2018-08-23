/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PioneerService } from './pioneer.service';

describe('Service: Pioneer', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PioneerService]
    });
  });

  it('should ...', inject([PioneerService], (service: PioneerService) => {
    expect(service).toBeTruthy();
  }));
});
