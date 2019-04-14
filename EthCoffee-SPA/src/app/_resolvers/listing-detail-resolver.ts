import { Injectable } from '@angular/core';
import { Listing } from '../_models/listing';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ListingService } from '../_services/listing.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ListingDetailResolver implements Resolve<Listing> {
  constructor(private listingService: ListingService, private router: Router,
              private alertify: AlertifyService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<Listing> {
    return this.listingService.getListing(route.params.id).pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/listings']);
        return of(null);
      })
    );
  }
}
