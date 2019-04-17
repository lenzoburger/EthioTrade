import { Component, OnInit } from '@angular/core';
import { Listing } from 'src/app/_models/listing';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-listing-edit',
  templateUrl: './listing-edit.component.html',
  styleUrls: ['./listing-edit.component.css']
})
export class ListingEditComponent implements OnInit {
  listing: Listing;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.listing = data.listing;
    });
  }

}
