import { Component, OnInit } from '@angular/core';
import { Listing } from 'src/app/_models/listing';
import { ListingService } from 'src/app/_services/listing.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-listing-detail',
  templateUrl: './listing-detail.component.html',
  styleUrls: ['./listing-detail.component.css']
})
export class ListingDetailComponent implements OnInit {
  listing: Listing;

  constructor(private listingService: ListingService, private alertify: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadListing();
  }

  loadListing() {
    this.listingService.getListing(+this.route.snapshot.params.id).subscribe((listing: Listing) => {
      this.listing = listing;
    }, error => {
      this.alertify.error(error);
    });
  }

}
