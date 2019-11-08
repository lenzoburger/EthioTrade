import { Component, OnInit } from '@angular/core';
import { Listing, ListedDates } from '../../_models/listing';
import { ListingService } from '../../_services/listing.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { FilterParams } from 'src/app/_models/filter-params';

@Component({
  selector: 'app-listings',
  templateUrl: './listings.component.html',
  styleUrls: ['./listings.component.css']
})
export class ListingsComponent implements OnInit {
  listings: Listing[];
  pagination: Pagination;
  filterParams: FilterParams;
  listedDates = Object.values(ListedDates);
  categories: string[] = ['All', 'Medical', 'Objects', 'Landscape', 'Paper & Books', 'Food & Drink'];

  constructor(
    private listingService: ListingService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {
    this.filterParams = this.initializeFilters();
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.listings = data.listings.result;
      this.pagination = data.listings.pagination;
    });
  }

  initializeFilters(): FilterParams {
    return {
      dateAdded: ListedDates.Any,
      category: this.categories[0],
      title: ''
    };
  }

  pageChanged(event: any): void {
    this.pagination.pageNumber = event.page;
    this.loadListings();
  }

  resetFilters() {
    this.filterParams = this.initializeFilters();
    this.loadListings();
  }

  loadListings() {
    this.listingService
      .getListings(this.pagination.pageNumber, this.pagination.pageSize, this.filterParams)
      .subscribe(
        (paginatedResult: PaginatedResult<Listing[]>) => {
          this.listings = paginatedResult.result;
          this.pagination = paginatedResult.pagination;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
