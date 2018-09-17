import { Component, OnInit } from '@angular/core';
import { IProduct } from '../core/entities/product';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: IProduct[];
  errorMessage: string;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getProducts()
      .subscribe(products => this.products = products,
                 error => this.errorMessage = error);
  }

}
