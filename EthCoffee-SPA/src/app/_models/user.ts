import { Avatar } from './avatar';

export interface User {
    id: number;
    username: string;
    firstname: string;
    lastname: string;
    streetNumber: string;
    street: string;
    city: string;
    country: string;
    zipCode: string;
    lastActiveDate: string;
    createdDate: string;
    bio: string;
    interests: string;
    avatarUrl: string;
    avatar: Avatar;
}
