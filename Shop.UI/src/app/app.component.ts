import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './user/authentication.service';
import { Router } from '@angular/router';
import { CartService } from './core/services/cart.service';
import { map } from 'rxjs/operators';
import { IProduct } from './core/entities/product';
import { OrderItem } from './core/entities/order';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Shop';
  itemCount = 0;

  ngOnInit(): void {
    this.cartService.itemsInCartSubject
    .subscribe((value: OrderItem[]) => {
      this.itemCount = 0;
      value.map(item => this.itemCount += item.quantity);
    });
  }

  constructor(
    public authService: AuthenticationService,
    private router: Router,
    public cartService: CartService) {}

  logOut(): void {
    this.authService.logout();
    this.router.navigateByUrl('/home');
}
}
