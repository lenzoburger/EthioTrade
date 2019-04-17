import { Avatar } from './avatar';

export interface User {
    id: number;
    username: string;
    city: string;
    country: string;
    lastActiveDate: string;
    createdDate: string;
    bio: string;
    avatarUrl: string;
    avatar: Avatar;
}
