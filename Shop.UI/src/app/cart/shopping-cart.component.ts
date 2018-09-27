import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/services/cart.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor(public cartService: CartService) { }

  ngOnInit() { }
}
