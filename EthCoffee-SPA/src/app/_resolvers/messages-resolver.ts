import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Message } from '../_models/message';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { MessageService } from '../_services/message.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MessagesResolver implements Resolve<Message[]> {
  pageNumber = 1;
  pageSize = 4;
  messageContainer = 'unread';

  constructor(
    private messagesService: MessageService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Message[]> {
    return this.messagesService
      .getMessages(this.pageNumber, this.pageSize, this.messageContainer)
      .pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving messages');
          this.router.navigate(['/home']);
          return of(null);
        })
      );
  }
}
