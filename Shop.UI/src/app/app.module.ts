import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { ProductListComponent } from './products/product-list.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductModule } from './products/product.module';
import { AppRoutingModule } from './app-routing.module';
import { ShoppingCartComponent } from './cart/shopping-cart.component';
import { LoginComponent } from './user/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthenticationService } from './user/authentication.service';
import { ProductPreviewComponent } from './products/product-preview.component';
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
    /*HttpClientInMemoryWebApiModule.forRoot(ProductDataService),*/
    ProductModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
