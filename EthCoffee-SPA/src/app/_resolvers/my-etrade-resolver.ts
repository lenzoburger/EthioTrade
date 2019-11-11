import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Listing } from '../_models/listing';
import { Injectable } from '@angular/core';
import { ListingService } from '../_services/listing.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserListsParams } from '../_models/filter-params';

@Injectable()
export class MyEtradeResolver implements Resolve<Listing[]> {
  pageNumber = 1;
  pageSize = 4;
  userListsParams: UserListsParams = { myListingsOnly: true, watchlistOnly: false };

  constructor(
    private listingService: ListingService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Listing[]> {
    return this.listingService
      .getListings(this.pageNumber, this.pageSize, null, this.userListsParams)
      .pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/home']);
          return of(null);
        })
      );
  }
}
