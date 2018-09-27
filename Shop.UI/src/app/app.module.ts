import { CartModule } from './cart/cart.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductModule } from './products/product.module';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './user/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user/user.service';
import { AccountComponent } from './user/account.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent,
    LoginComponent,
    AccountComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('access_token'),
        whitelistedDomains: ['localhost:4377'],
        blacklistedRoutes: ['localhost:4377/accounts/']
      }
    }),
    /*HttpClientInMemoryWebApiModule.forRoot(ProductDataService),*/
    ProductModule,
    CartModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
