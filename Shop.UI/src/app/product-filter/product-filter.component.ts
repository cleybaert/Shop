import { Component, OnInit } from '@angular/core';
import { Category } from '../core/entities/category';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit {

  categories: Category[] = [];
  errorMessage: string;

  constructor(
    private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getCategories()
      .subscribe(products => this.categories = products,
                 error => this.errorMessage = error);
  }

}
