import { ListingPhoto } from './listingPhoto';
import { User } from './user';
import { IDict } from './_IDict';

export interface Listing {
  id: number;
  category: string;
  title: string;
  price: string;
  dateAdded: string;
  listingPhotoUrl: string;

  watching?: boolean;
  description?: string;
  watcherCount?: number;
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

export enum SortBy {
  DateAdded_Desc = 'Latest Listing',
  DateAdded = 'Oldest Listing',
  Price = 'Lowest Price',
  Price_Desc = 'Highest Price'
}

export const ListingSortDict: IDict<string> = {
  [SortBy.DateAdded_Desc]: 'dateAdded_desc',
  [SortBy.DateAdded]: 'dateAdded',
  [SortBy.Price_Desc]: 'price_desc',
  [SortBy.Price]: 'price'
};
