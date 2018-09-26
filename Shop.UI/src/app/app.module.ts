import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductModule } from './products/product.module';
import { AppRoutingModule } from './app-routing.module';
import { ShoppingCartComponent } from './cart/shopping-cart.component';
import { LoginComponent } from './user/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user/user.service';
import { CartItemComponent } from './cart/cart-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent,
    ShoppingCartComponent,
    LoginComponent,
    CartItemComponent,
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
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
