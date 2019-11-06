import { Component, OnInit } from '@angular/core';
import { Listing } from '../../_models/listing';
import { ListingService } from '../../_services/listing.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-listings',
  templateUrl: './listings.component.html',
  styleUrls: ['./listings.component.css']
})
export class ListingsComponent implements OnInit {
  listings: Listing[];
  pagination: Pagination;

  constructor(
    private listingService: ListingService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

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
    this.listingService.getListings(this.pagination.pageNumber, this.pagination.pageSize).subscribe(
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
