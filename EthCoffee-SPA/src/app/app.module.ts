import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';

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
    ListingEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    NgxGalleryModule,
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      },
    })
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
    ListingEditResolver
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
