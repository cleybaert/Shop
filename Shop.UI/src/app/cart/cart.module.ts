import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ShoppingCartComponent } from './shopping-cart.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: ShoppingCartComponent,
        outlet: 'cart'
      }
    ])
  ],
  declarations: []
})
export class CartModule { }
