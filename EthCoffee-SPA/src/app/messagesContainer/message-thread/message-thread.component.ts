import { Component, OnInit, Input, ViewChild, ElementRef, AfterViewChecked } from '@angular/core';
import { Message, UserInfo } from 'src/app/_models/message';
import { MessageService } from 'src/app/_services/message.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-message-thread',
  templateUrl: './message-thread.component.html',
  styleUrls: ['./message-thread.component.css']
})
export class MessageThreadComponent implements OnInit, AfterViewChecked {
  @ViewChild('messagesContainer', { static: true }) private messagesContainer: ElementRef;

  recipient: UserInfo;
  @Input()
  set messageRecipient(Recipient: UserInfo) {
    this.recipient = Recipient;
    this.loadMessages();
  }
  messages: Message[];
  newMessage: any = {};
  prevMessagesLength = 0;

  constructor(
    private messageService: MessageService,
    private alertify: AlertifyService,
    private authservice: AuthService
  ) { }

  ngOnInit() {
    this.scrollToBottom();
  }

  ngAfterViewChecked() {
    if (this.messages && this.prevMessagesLength !== this.messages.length) {
      this.scrollToBottom();
      this.prevMessagesLength = this.messages.length;
    }
  }

  scrollToBottom(): void {
    try {
      this.messagesContainer.nativeElement.scrollTop = this.messagesContainer.nativeElement.scrollHeight;
    } catch (err) {
      this.alertify.error(err);
    }
  }

  loadMessages() {
    const currentUserId = +this.authservice.decodedToken.nameid;

    this.messageService
      .getMessageThread(this.recipient.id)
      .pipe(
        tap((messages: Message[]) => {
          messages.forEach(element => {
            if (!element.isRead && element.recipientId === currentUserId) {
              this.messageService.markAsRead(element.id);
            }
          });
        })
      )
      .subscribe(
        messages => {
          this.prevMessagesLength = this.messages ? this.messages.length : 0;
          this.messages = messages;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  sendMessage() {
    this.newMessage.recipientId = this.recipient.id;
    this.messageService
      .sendMessage(this.newMessage)
      .subscribe((message: Message) => {
        this.prevMessagesLength = this.messages ? this.messages.length : 0;
        this.messages.unshift(message);
        this.newMessage.content = '';
      });
  }
}
