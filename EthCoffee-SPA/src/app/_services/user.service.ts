import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { User } from '../_models/user';
import { UserListing } from '../_models/userListing';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public changeAvatar = false;
  baseUrl = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) {}

  getUserDetails(id): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/${id}`);
  }

  getUserListings(id): Observable<UserListing> {
    return this.http.get<UserListing>(`${this.baseUrl}/${id}/listings`);
  }

  updateUserDetails(id: number, userDetails: User) {
    return this.http.put(`${this.baseUrl}/${id}`, userDetails);
  }

  watchListing(id: number, listingId: number) {
    return this.http.post(`${this.baseUrl}/${id}/watch/${listingId}`, {});
  }
}
