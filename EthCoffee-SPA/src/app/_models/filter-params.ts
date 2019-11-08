import { ListedDates, SortBy } from './listing';

export interface FilterParams {
    dateAdded: ListedDates;
    category: string;
    title: string;
    sortBy: SortBy;
}
