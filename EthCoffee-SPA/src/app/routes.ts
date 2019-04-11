import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListingsComponent } from './listingsContainer/listings/listings.component';
import { MyEtradeComponent } from './my-etrade/my-etrade.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { ListingDetailComponent } from './listingsContainer/listing-detail/listing-detail.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'listings', component: ListingsComponent },
            { path: 'listings/:id', component: ListingDetailComponent },
            { path: 'myetrade', component: MyEtradeComponent },
            { path: 'messages', component: MessagesComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];
