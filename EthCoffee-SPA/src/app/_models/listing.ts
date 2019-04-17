import { ListingPhoto } from './listingPhoto';
import { User } from './user';

export interface Listing {
    id: number;
    category: string;
    title: string;
    dateAdded: string;
    listingPhotoUrl: string;

    description?: string;
    photos?: ListingPhoto[];
    user?: User;
}
