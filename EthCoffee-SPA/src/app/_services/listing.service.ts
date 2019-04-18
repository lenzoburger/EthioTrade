import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { Listing } from '../_models/listing';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})
export class ListingService {
  private currentListingData: Listing;
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private authService: AuthService) { }

  getListing(id): Observable<Listing> {
    return this.http.get<Listing>(this.baseUrl + 'listings/' + id);
  }

  getListings(): Observable<Listing[]> {
    return this.http.get<Listing[]>(this.baseUrl + 'listings');
  }

  updateCurrentListingData(updatedlisting: Listing) {
    this.currentListingData = updatedlisting;
  }

  getCurrentListingData(): Observable<Listing> {
    if (this.currentListingData) {
      if (this.authService.loggedIn() && '' + this.currentListingData.user.id
        === this.authService.decodedToken.nameid) {
        return of(this.currentListingData);
      } else {
        return throwError('Login is required to perform this action...');
      }
    } else {
      return throwError('Returning to listing ...');
    }
  }

  updateListing(id: number, listing: Listing) {
    return this.http.put(this.baseUrl + 'listings/' + id, listing);
  }
}
