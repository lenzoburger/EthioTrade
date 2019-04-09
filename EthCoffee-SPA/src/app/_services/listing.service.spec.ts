/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ListingService } from './listing.service';

describe('Service: Listing', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListingService]
    });
  });

  it('should ...', inject([ListingService], (service: ListingService) => {
    expect(service).toBeTruthy();
  }));
});
