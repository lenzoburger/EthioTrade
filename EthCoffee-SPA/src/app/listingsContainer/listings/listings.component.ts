import { Component, OnInit } from '@angular/core';
import { Listing } from '../../_models/listing';
import { ListingService } from '../../_services/listing.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-listings',
  templateUrl: './listings.component.html',
  styleUrls: ['./listings.component.css']
})
export class ListingsComponent implements OnInit {
  listings: Listing[];

  constructor(private listingService: ListingService, private alertify: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.listings = data.listings.result;
    });
  }

  // loadListings() {
  //   this.listingService.getListings().subscribe((listings: Listing[]) => {
  //     this.listings = listings;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }

}
