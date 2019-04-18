/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ListingEditService } from './listing-edit.service';

describe('Service: ListingEdit', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListingEditService]
    });
  });

  it('should ...', inject([ListingEditService], (service: ListingEditService) => {
    expect(service).toBeTruthy();
  }));
});
