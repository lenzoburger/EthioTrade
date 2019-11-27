import { Component, OnInit } from '@angular/core';
import { MessageService } from '../../_services/message.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Message, UserInfo } from '../../_models/message';
import { Pagination, PaginatedResult } from '../../_models/pagination';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[];
  pagination: Pagination;
  messageContainer = 'Unread';
  recipient: UserInfo;

  constructor(
    private messagesService: MessageService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.messages = data.messages.result;
      this.pagination = data.messages.pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.pageNumber = event.page;
    this.loadMessages();
  }

  loadMessageThread(recipient: UserInfo) {
    this.recipient = { ...recipient };
  }

  loadMessages() {
    this.messagesService
      .getMessages(this.pagination.pageNumber, this.pagination.pageSize, this.messageContainer)
      .subscribe(
        (paginatedResult: PaginatedResult<Message[]>) => {
          this.messages = paginatedResult.result;
          this.pagination = paginatedResult.pagination;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  deleteMessage(messageId: number) {
    this.alertify.confirm('Are you sure you want to delete this message?', () => {
      this.messagesService.deletedMessage(messageId).subscribe(
        () => {
          this.messages.splice(this.messages.findIndex(m => m.id === messageId), 1);
          this.alertify.success('Message has been deleted');
        },
        error => {
          this.alertify.error('Failed to delete message');
        }
      );
    });
  }
}
