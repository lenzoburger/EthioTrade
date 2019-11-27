import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Message } from '../_models/message';
import { PaginatedResult } from '../_models/pagination';
import { HttpParams, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  userId = this.authService.decodedToken.nameid;
  baseUrl = `${environment.apiUrl}/users/${this.userId}/messages`;

  constructor(private authService: AuthService, private http: HttpClient) {}

  getMessages(pageNumber?, pageSize?, messageContainer?): Observable<PaginatedResult<Message[]>> {
    const paginatedResult: PaginatedResult<Message[]> = new PaginatedResult<Message[]>();

    let params = new HttpParams();

    if (pageNumber != null) {
      params = params.append('pageNumber', pageNumber);
    }

    if (pageSize != null) {
      params = params.append('pageSize', pageSize);
    }

    if (messageContainer != null) {
      params = params.append('messageContainer', messageContainer);
    }

    return this.http
      .get<Message[]>(this.baseUrl, { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  getMessageThread(recipientId: number) {
    return this.http.get<Message[]>(`${this.baseUrl}/thread/${recipientId}`);
  }

  sendMessage(message: Message) {
    return this.http.post<Message>(this.baseUrl, message);
  }
}
