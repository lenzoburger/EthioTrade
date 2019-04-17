import { Injectable } from '@angular/core';
import { Listing } from '../_models/listing';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ListingService } from '../_services/listing.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ListingEditResolver implements Resolve<Listing> {
  constructor(private listingService: ListingService, private router: Router,
              private alertify: AlertifyService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<Listing> {
    // if(ListingService.UserIsAuthenticated)
    return this.listingService.getCurrentListingData().pipe(
      catchError(error => {
        this.alertify.message(error);
        this.router.navigate(['listings/' + route.params.id]);
        return of(null);
      })
    );
    // Else(alertify (You do not have access to edit this listing))
  }
}
