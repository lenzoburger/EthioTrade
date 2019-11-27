export interface Message {
  id: number;

  senderId: number;
  senderUsername: string;
  senderAvatarUrl: string;

  recipientId: number;
  recipientUsername: string;
  recipientAvatarUrl: string;

  content: string;
  isRead: boolean;
  dateRead?: Date;
  messageSent: Date;
}

export interface UserInfo {
  id: number;
  username: string;
  avatarUrl: string;
}
