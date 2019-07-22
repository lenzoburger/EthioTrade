export interface Pagination {
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    totalItems: number;
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}