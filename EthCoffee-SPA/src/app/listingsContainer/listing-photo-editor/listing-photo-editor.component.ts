import { Component, OnInit, Input } from '@angular/core';
import { ListingPhoto } from 'src/app/_models/listingPhoto';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { ListingService } from 'src/app/_services/listing.service';

@Component({
  selector: 'app-listing-photo-editor',
  templateUrl: './listing-photo-editor.component.html',
  styleUrls: ['./listing-photo-editor.component.css']
})
export class ListingPhotoEditorComponent implements OnInit {
  @Input() listingPhotos: ListingPhoto[];
  @Input() listingId: number;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  hasAnotherDropZoneOver = false;
  baseUrl = environment.apiUrl;

  constructor() { }

  ngOnInit() {
    this.intializerUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  intializerUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'listings/' + this.listingId + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: ListingPhoto = JSON.parse(response);
        const listingPhoto = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description,
          IsMain: res.IsMain
        };
        this.listingPhotos.push(listingPhoto);
      }
    };
  }

}
