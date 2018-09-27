import { OrderItem } from './../core/entities/order';
import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/services/cart.service';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.css']
})
export class CartListComponent implements OnInit {

  private errorMessage;

  public orders: OrderItem[] = [];

  constructor(
    private cartService: CartService,
    private dataService: DataService) { }

  ngOnInit() {
    this.cartService.orderItems.subscribe(value => {
      JSON.stringify(value);
      this.orders = value;
    },
    err => console.log('Error in cart service!!!'));
  }
}
