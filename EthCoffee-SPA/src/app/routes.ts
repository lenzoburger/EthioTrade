import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListingsComponent } from './listingsContainer/listings/listings.component';
import { MyEtradeComponent } from './my-etrade/my-etrade.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { ListingDetailComponent } from './listingsContainer/listing-detail/listing-detail.component';
import { ListingDetailResolver } from './_resolvers/listing-detail-resolver';
import { ListingsResolver } from './_resolvers/listings-resolver';
import { ListingEditComponent } from './listingsContainer/listing-edit/listing-edit.component';
import { ListingEditResolver } from './_resolvers/listing-edit-resolver';
import { MyAccountComponent } from './account/my-account/my-account.component';
import { MyAccountResolver } from './_resolvers/my-account-resolver';
import { MyAccountEditComponent } from './account/my-account-edit/my-account-edit.component';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'listings', component: ListingsComponent,
        resolve: { listings: ListingsResolver }
      },
      {
        path: 'listings/edit/:id', component: ListingEditComponent,
        resolve: { listing: ListingEditResolver }, canDeactivate: [PreventUnsavedChanges]
      },
      {
        path: 'listings/:id', component: ListingDetailComponent,
        resolve: { listing: ListingDetailResolver }
      },
      {
        path: 'account/edit', component: MyAccountEditComponent,
        resolve: { user: MyAccountResolver }, canDeactivate: [PreventUnsavedChanges]
      },
      {
        path: 'account', component: MyAccountComponent,
        resolve: { user: MyAccountResolver }
      },
      { path: 'myetrade', component: MyEtradeComponent },
      { path: 'messages', component: MessagesComponent },
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
