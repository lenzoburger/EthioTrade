import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ListingEditComponent } from '../listingsContainer/listing-edit/listing-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<ListingEditComponent> {
  canDeactivate(component: ListingEditComponent) {
    if (component.editForm.dirty) {
      return confirm('Are you sure want to continue? Any unsaved changes will be lost');
    }
    return true;
  }
}
