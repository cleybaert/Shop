import { AuthenticationGuard } from './../user/authentication.guard';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ShoppingCartComponent } from './shopping-cart.component';
import { CheckoutComponent } from './checkout.component';
import { CartListComponent } from './cart-list.component';
import { CartItemComponent } from './cart-item.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'checkout', component: CheckoutComponent, canActivate: [AuthenticationGuard]},
      {
        path: '',
        component: ShoppingCartComponent,
        outlet: 'cart'
      }
    ]),
    CommonModule,
  ],
  exports: [RouterModule, ShoppingCartComponent],
  declarations: [
    CartListComponent,
    CheckoutComponent,
    CartItemComponent,
    ShoppingCartComponent
  ]
})
export class CartModule { }
