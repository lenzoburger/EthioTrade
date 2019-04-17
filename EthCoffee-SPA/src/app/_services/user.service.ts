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
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUserDetails(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getUserListings(id): Observable<UserListing> {
    return this.http.get<UserListing>(this.baseUrl + 'users/listings/' + id);
  }
}
