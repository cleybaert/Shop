import { Component, OnInit, Input } from '@angular/core';
import { OrderItemViewModel } from '../core/viewmodels/order-item';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
  @Input() orderItem: OrderItemViewModel;

  constructor() {
    console.log('Cart item created');
   }

  ngOnInit() {
  }

}
