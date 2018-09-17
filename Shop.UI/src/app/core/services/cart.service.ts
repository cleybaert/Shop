import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { OrderItem } from '../entities/order';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  itemsInCartSubject: BehaviorSubject<OrderItem[]> = new BehaviorSubject([]);
  private itemsInCart: OrderItem[] = [];

  constructor() {
    this.itemsInCartSubject.subscribe(value => this.itemsInCart = value);
  }

  private equals(value1, value2: OrderItem): boolean {
    if (!(value2.productid === value1.productid)) {
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
    const current = this.itemsInCart.find(citem => this.equals(item, citem));
    if (current) {
      current.quantity += item.quantity;
    } else {
      this.itemsInCart.push(item);
    }
    this.itemsInCartSubject.next(this.itemsInCart);
  }

  addToCart(productid: number, quantity: number, options: Map<string, string>) {
    const item: OrderItem = {
      productid: productid,
      quantity: quantity,
      options: options
    };
    this.add(item);
    const total = this.productCount(productid);
    this.log(`${total} item(s) of product '${productid}' in cart`);
  }

  productCount(productid: number): number {
    return _.sum(this.itemsInCart.map(item => item.quantity));
  }

  log(message: string) {
    console.log(`CartService: ${message}`);
  }
}
