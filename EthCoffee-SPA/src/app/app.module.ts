import { BrowserModule } from '@angular/platform-browser';
import { BsDropdownModule, TabsModule, BsDatepickerModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { NgModule } from '@angular/core';
import { NgxGalleryModule } from 'ngx-gallery';
import { RouterModule } from '@angular/router';
import {TimeAgoPipe} from 'time-ago-pipe';

import { AlertifyService } from './_services/alertify.service';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard } from './_guards/auth.guard';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { HomeComponent } from './home/home.component';
import { ListingCardComponent } from './listingsContainer/listing-card/listing-card.component';
import { ListingDetailComponent } from './listingsContainer/listing-detail/listing-detail.component';
import { ListingDetailResolver } from './_resolvers/listing-detail-resolver';
import { ListingEditComponent } from './listingsContainer/listing-edit/listing-edit.component';
import { ListingEditResolver } from './_resolvers/listing-edit-resolver';
import { ListingPhotoEditorComponent } from './listingsContainer/listing-photo-editor/listing-photo-editor.component';
import { ListingService } from './_services/listing.service';
import { ListingsComponent } from './listingsContainer/listings/listings.component';
import { ListingsResolver } from './_resolvers/listings-resolver';
import { MessagesComponent } from './messages/messages.component';
import { MyAccountComponent } from './account/my-account/my-account.component';
import { MyAccountEditComponent } from './account/my-account-edit/my-account-edit.component';
import { MyAccountResolver } from './_resolvers/my-account-resolver';
import { MyEtradeComponent } from './my-etrade/my-etrade.component';
import { NavComponent } from './nav/nav.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RegisterComponent } from './register/register.component';
import { UserService } from './_services/user.service';
import { appRoutes } from './routes';
import { MyEtradeResolver } from './_resolvers/my-etrade-resolver';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { MessageService } from './_services/message.service';
import { MessagesResolver } from './_resolvers/messages-resolver';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListingCardComponent,
    ListingDetailComponent,
    ListingEditComponent,
    ListingPhotoEditorComponent,
    ListingsComponent,
    MessagesComponent,
    MyAccountComponent,
    MyAccountEditComponent,
    MyEtradeComponent,
    NavComponent,
    RegisterComponent,
    TimeAgoPipe
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    FileUploadModule,
    FormsModule,
    HttpClientModule,
    NgxGalleryModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    TabsModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      },
    }),
    ButtonsModule.forRoot()
  ],
  providers: [
    AlertifyService,
    AuthGuard,
    AuthService,
    ErrorInterceptorProvider,
    ListingDetailResolver,
    ListingEditResolver,
    ListingService,
    ListingsResolver,
    MessagesResolver,
    MessageService,
    MyAccountResolver,
    MyEtradeResolver,
    PreventUnsavedChanges,
    UserService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
