import { ListingPhoto } from './listingPhoto';

export interface Listing {
    id: number;
    category: string;
    title: string;
    dateAdded: string;
    listingPhotoUrl: string;

    description?: string;
    listingPhotos?: ListingPhoto[];
}
