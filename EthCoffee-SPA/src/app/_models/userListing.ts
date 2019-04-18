import { Avatar } from './avatar';
import { Listing } from './Listing';

export interface UserListing {
    id: number;
    username: string;
    city: string;
    country: string;
    lastActiveDate: string;
    createdDate: string;
    bio: string;
    avatarUrl: string;
    avatar: Avatar;
    myListings: Listing[];
}
