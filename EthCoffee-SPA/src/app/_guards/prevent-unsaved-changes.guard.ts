import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ListingEditComponent } from '../listingsContainer/listing-edit/listing-edit.component';
import { MyAccountEditComponent } from '../account/my-account-edit/my-account-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<ListingEditComponent | MyAccountEditComponent> {
  canDeactivate(component: ListingEditComponent | MyAccountEditComponent) {
    if (component.editForm.dirty) {
      return confirm('Are you sure want to continue? Any unsaved changes will be lost');
    }
    return true;
  }
}
