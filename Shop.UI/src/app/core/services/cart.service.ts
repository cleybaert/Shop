import { IProduct } from './../entities/product';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { OrderItem } from '../entities/order';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  orderItems: BehaviorSubject<OrderItem[]> = new BehaviorSubject([]);

  private orderItemsList: OrderItem[] = [];

  constructor() {
    console.log('CartService created');
  }

  get totalItems(): number {
    if (this.orderItemsList.length = 0) {
      return 0;
    } else {
      return _.sum(
        this.orderItemsList.map(orderItem => {
          return orderItem.quantity;
        })
      );
    }
  }

  get totalPrice(): number {
    if (this.orderItemsList.length = 0) {
      return 0;
    } else {
      return _.sum(
        this.orderItemsList.map(orderItem => {
          return orderItem.quantity * orderItem.product.price;
        })
      );
    }
  }

  private equals(value1, value2: OrderItem): boolean {
    if (!(value2.product.id === value1.product.id)) {
      return false;
    }
    if (!(value2.options.size === value1.options.size)) {
      return false;
    }
    let found = true;
    value2.options.forEach((val, key) => {
      if (value1.options.has(key)) {
        if (!(value1.options.get(key) === val)) {
          found = false;
        }
      } else {
        found = false;
      }
    });
    return found;
  }

  private add(item: OrderItem) {
    const current = this.orderItemsList.find(citem => this.equals(item, citem));
    if (current) {
      current.quantity += item.quantity;
    } else {
      this.orderItemsList.push(item);
    }
    this.orderItems.next(this.orderItemsList);
  }

  addToCart(product: IProduct, quantity: number, options: Map<string, string>) {
    const item: OrderItem = {
      product: product,
      quantity: quantity,
      options: options
    };
    this.add(item);
    const total = this.productCount(product.id);
    this.log(`${total} item(s) of product '${product.id}' in cart`);
  }

  productCount(productid: number): number {
    return _.sum(this.orderItemsList.filter(item => item.product.id === productid).map(item => item.quantity));
  }

  log(message: string) {
    console.log(`CartService: ${message}`);
  }
}
