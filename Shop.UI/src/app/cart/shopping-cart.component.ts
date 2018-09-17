import { Component, OnInit } from '@angular/core';
import { IProduct } from '../core/entities/product';
import { OrderViewModel } from '../core/viewmodels/order';
import { CartService } from '../core/services/cart.service';
import { OrderItem, Order } from '../core/entities/order';
import { OrderItemViewModel } from '../core/viewmodels/order-item';
import { DataService } from '../core/services/data.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  private products: IProduct[];
  private errorMessage;

  public order: OrderViewModel;

  constructor(
    private cartService: CartService,
    private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getProducts().subscribe(
      value => {
        this.products = value;
      }
    );
    this.cartService.itemsInCartSubject.subscribe((value: OrderItem[]) => {
      this.order = {
        orders: value.map(orderItem => {
          return this.getOrderItemViewModel(orderItem);
        }),
        total: _.sum(value.map(orderItem => {
          const product = this.products.find(prod => prod.id === orderItem.productid);
          if (!product) {
            console.log(`Failed to calculate total: product ${orderItem.productid} not found`);
            return 0;
          }
          return orderItem.quantity * product.price;
        })),
        shipping: 200
      };
    });
  }

  getOrderItemViewModel(order: OrderItem): OrderItemViewModel {
    const product = this.products.find(prod => prod.id === order.productid);
    if (!product) {
      console.log(`Product ${order.productid} not found`);
      return null;
    }
    return {
      productName: product.name,
      quantity: order.quantity,
      price: product.price,
      subtotal: product.price * order.quantity,
      preview: product.url
    };
  }

  getOrderViewModel(order: Order): OrderViewModel {
    return {
      orders: order.items.map(item => {
        return this.getOrderItemViewModel(item);
      }),
      total: 100,
      shipping: 0
    };
  }
}
