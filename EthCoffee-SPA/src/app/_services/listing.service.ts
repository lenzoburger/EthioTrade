import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Listing } from '../_models/listing';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ListingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getListing(id): Observable<Listing> {
    return this.http.get<Listing>(this.baseUrl + 'listings/' + id, httpOptions);
  }

  getListings(): Observable<Listing[]> {
    return this.http.get<Listing[]>(this.baseUrl + 'listings', httpOptions);
  }
}
