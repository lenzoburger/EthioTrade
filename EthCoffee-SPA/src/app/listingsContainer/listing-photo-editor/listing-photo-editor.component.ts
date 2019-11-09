import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ListingPhoto } from 'src/app/_models/listingPhoto';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { ListingService } from 'src/app/_services/listing.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-listing-photo-editor',
  templateUrl: './listing-photo-editor.component.html',
  styleUrls: ['./listing-photo-editor.component.css']
})
export class ListingPhotoEditorComponent implements OnInit {
  @Input() listingPhotos: ListingPhoto[];
  @Input() listingId: number;
  @Output() getListingPhotoChange = new EventEmitter<string>();
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  hasAnotherDropZoneOver = false;
  baseUrl = environment.apiUrl;
  currentMainPhoto: ListingPhoto;

  constructor(private listingService: ListingService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.intializerUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  intializerUploader() {
    this.uploader = new FileUploader({
      url: `${this.baseUrl}/listings/${this.listingId}/photos`,
      authToken: `Bearer ${localStorage.getItem('token')}`,
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
          isMain: res.isMain
        };
        this.listingPhotos.push(listingPhoto);
      }
    };
  }

  setMainPhoto(listingPhoto: ListingPhoto) {
    this.listingService.setMainPhoto(this.listingId, listingPhoto.id).subscribe(() => {
      this.currentMainPhoto = this.listingPhotos.filter(p => p.isMain === true)[0];
      this.currentMainPhoto.isMain = false;
      listingPhoto.isMain = true;
      this.getListingPhotoChange.emit(listingPhoto.url);
    }, error => {
      this.alertify.error(error);
    });
  }

  deletePhoto(id: number) {
    this.alertify.confirm('Are you sure you want to delete this photo?', () => {
      this.listingService.deletePhoto(this.listingId, id).subscribe(() => {
        this.listingPhotos.splice(this.listingPhotos.findIndex(p => p.id === id), 1);
        this.alertify.success('Photo has been deleted');
      }, error => {
        this.alertify.error('Failed to delete photo: ' + error);
      });
    });
  }

}
