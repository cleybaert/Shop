import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './user/authentication.service';
import { Router } from '@angular/router';
import { CartService } from './core/services/cart.service';
import { OrderItem } from './core/entities/order';
import { Category } from './core/entities/category';
import { CategoryService } from './core/services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Shop';
  itemCount = 0;
  categories: Category[];
  errorMessage: string;

  ngOnInit(): void {
    this.cartService.itemsInCartSubject
    .subscribe((value: OrderItem[]) => {
      this.itemCount = 0;
      value.map(item => this.itemCount += item.quantity);
    });
    this.categoryService.getCategories()
      .subscribe(values => this.categories = values,
                 error => this.errorMessage = error);
  }

  constructor(
    public authService: AuthenticationService,
    private router: Router,
    public cartService: CartService,
    private categoryService: CategoryService) {}

  logOut(): void {
    this.authService.logout();
    this.router.navigateByUrl('/home');
  }
}
