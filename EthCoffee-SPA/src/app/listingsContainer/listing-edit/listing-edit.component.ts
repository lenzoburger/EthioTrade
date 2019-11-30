import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Listing } from 'src/app/_models/listing';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ListingService } from 'src/app/_services/listing.service';

@Component({
  selector: 'app-listing-edit',
  templateUrl: './listing-edit.component.html',
  styleUrls: ['./listing-edit.component.css']
})
export class ListingEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  listing: Listing;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute, private alertify: AlertifyService, private listingService: ListingService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.listing = data.listing;
    });
  }

  updateListing() {
    this.listingService.updateListing(this.listing.id, this.listing).subscribe(next => {
      this.alertify.success('Listing update successfully');
      this.editForm.reset(this.listing);
    }, error => {
      this.alertify.error(error);
    });
  }

  updateMainPhoto(url: string) {
    this.listing.listingPhotoUrl = url;
  }
}
