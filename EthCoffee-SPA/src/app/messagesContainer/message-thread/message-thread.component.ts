import { Component, OnInit, Input } from "@angular/core";
import { Message, UserInfo } from "src/app/_models/message";
import { MessageService } from "src/app/_services/message.service";
import { AlertifyService } from "src/app/_services/alertify.service";
import { AuthService } from "src/app/_services/auth.service";
import { tap } from "rxjs/operators";

@Component({
  selector: "app-message-thread",
  templateUrl: "./message-thread.component.html",
  styleUrls: ["./message-thread.component.css"]
})
export class MessageThreadComponent implements OnInit {
  recipient: UserInfo;
  @Input()
  set messageRecipient(Recipient: UserInfo) {
    this.recipient = Recipient;
    this.loadMessages();
  }
  messages: Message[];
  newMessage: any = {};

  constructor(
    private messageService: MessageService,
    private alertify: AlertifyService,
    private authservice: AuthService
  ) {}

  ngOnInit() {}

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
        this.messages.unshift(message);
        this.newMessage.content = "";
      });
  }
}
