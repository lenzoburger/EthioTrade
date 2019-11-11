import { Component, OnInit } from '@angular/core';
import { Listing } from '../_models/listing';
import { Pagination, PaginatedResult } from '../_models/pagination';
import { UserListsParams } from '../_models/filter-params';
import { ListingService } from '../_services/listing.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-my-etrade',
  templateUrl: './my-etrade.component.html',
  styleUrls: ['./my-etrade.component.css']
})
export class MyEtradeComponent implements OnInit {
  listings: Listing[];
  pagination: Pagination;
  userListsParams: UserListsParams;
  currentTab = 'myListings';

  constructor(
    private listingService: ListingService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {
    this.userListsParams = {
      myListingsOnly: this.currentTab === 'myListings',
      watchlistOnly: this.currentTab === 'myWatchList'
    };
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.listings = data.listings.result;
      this.pagination = data.listings.pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.pageNumber = event.page;
    this.loadListings();
  }

  loadListings() {
    this.userListsParams = {
      myListingsOnly: this.currentTab === 'myListings',
      watchlistOnly: this.currentTab === 'myWatchList'
    };
    this.listingService
      .getListings(this.pagination.pageNumber, this.pagination.pageSize, null, this.userListsParams)
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
