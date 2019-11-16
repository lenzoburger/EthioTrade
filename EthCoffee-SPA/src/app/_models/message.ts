export interface Message {
  Id: number;

  SenderId: number;
  SenderUsername: string;
  SenderAvatarUrl: string;

  RecipientId: number;
  RecipientUsername: string;
  RecipientAvatarUrl: string;

  Content: string;
  IsRead: boolean;
  DateRead?: Date;
  MessageSent: Date;
}
