import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { Listing } from '../_models/listing';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ListingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private authService: AuthService) { }

  getListing(id): Observable<Listing> {
    return this.http.get<Listing>(this.baseUrl + 'listings/' + id);
  }

  getListings(): Observable<Listing[]> {
    return this.http.get<Listing[]>(this.baseUrl + 'listings');
  }

  getListingForEdit(id): Observable<Listing> {
    if (this.authService.loggedIn()) {
      return this.getListing(id).pipe(
        map(listing => {
          if ('' + listing.user.id === this.authService.decodedToken.nameid) {
            return listing;
          } else {
            throw new Error();
          }
        }), catchError(error => {
          return throwError('Login required to perform this action');
        }));
    } else {
      return throwError('Please login.');
    }
  }

  updateListing(id: number, listing: Listing) {
    return this.http.put(this.baseUrl + 'listings/' + id, listing);
  }
}
