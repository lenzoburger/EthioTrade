import { Component, OnInit, Input } from '@angular/core';
import { Listing } from 'src/app/_models/listing';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-listing-card',
  templateUrl: './listing-card.component.html',
  styleUrls: ['./listing-card.component.css']
})
export class ListingCardComponent implements OnInit {
  @Input() listing: Listing;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {}

  watchListing(listingId: number) {
    this.userService.watchListing(this.authService.decodedToken.nameid, listingId).subscribe(
      (data: any) => {
        if (data.action === 'Watch') {
          this.alertify.success('Listing added to Watchlist');
          this.listing.watching = true;
        } else {
          this.alertify.warning('Listing removed from Watchlist');
          this.listing.watching = false;
        }
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
