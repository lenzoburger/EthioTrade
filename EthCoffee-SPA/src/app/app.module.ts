import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule, BsDatepickerModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import {TimeAgoPipe} from 'time-ago-pipe';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from 'selenium-webdriver/http';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { ListingsComponent } from './listingsContainer/listings/listings.component';
import { MyEtradeComponent } from './my-etrade/my-etrade.component';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { ListingService } from './_services/listing.service';
import { ListingCardComponent } from './listingsContainer/listing-card/listing-card.component';
import { ListingDetailComponent } from './listingsContainer/listing-detail/listing-detail.component';
import { ListingDetailResolver } from './_resolvers/listing-detail-resolver';
import { ListingsResolver } from './_resolvers/listings-resolver';
import { ListingEditComponent } from './listingsContainer/listing-edit/listing-edit.component';
import { ListingEditResolver } from './_resolvers/listing-edit-resolver';
import { MyAccountComponent } from './account/my-account/my-account.component';
import { MyAccountResolver } from './_resolvers/my-account-resolver';
import { MyAccountEditComponent } from './account/my-account-edit/my-account-edit.component';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ListingPhotoEditorComponent } from './listingsContainer/listing-photo-editor/listing-photo-editor.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    ListingsComponent,
    MyEtradeComponent,
    MessagesComponent,
    ListingCardComponent,
    ListingDetailComponent,
    ListingEditComponent,
    MyAccountComponent,
    MyAccountEditComponent,
    ListingPhotoEditorComponent,
    TimeAgoPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxGalleryModule,
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    FileUploadModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      },
    }),
    PaginationModule.forRoot()
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    UserService,
    ListingService,
    ListingDetailResolver,
    ListingsResolver,
    ListingEditResolver,
    MyAccountResolver,
    PreventUnsavedChanges
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
