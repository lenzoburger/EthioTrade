import { ListingPhoto } from './listingPhoto';
import { User } from './user';

export interface Listing {
  id: number;
  category: string;
  title: string;
  price: string;
  dateAdded: string;
  listingPhotoUrl: string;

  description?: string;
  photos?: ListingPhoto[];
  user?: User;
}

export enum ListedDates {
  Any = 'Any Time',
  Today = 'Today',
  Yesterday = 'Yesterday',
  ThisWeek = 'This Week',
  ThisMonth = 'This Month'
}
