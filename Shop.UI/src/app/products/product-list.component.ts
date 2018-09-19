import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from '../core/entities/product';
import { DataService } from '../core/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../core/entities/category';
import { CategoryService } from '../core/services/category.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public selectedRootCategory: Category;
  public selectedCategory: Category;
  public selectedTree: Category[] = [];
  products: IProduct[];
  categories: Category[] = [];
  errorMessage: string;

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private categoryService: CategoryService) { }

  ngOnInit() {
    this.categoryService.getCategories()
      .subscribe(categories => this.categories = categories,
                  error => this.errorMessage = error);

    this.route.queryParams.subscribe((params: any) => {
      const categoryId = params.category;

      this.categoryService.getCategory(categoryId).subscribe(c =>
        this.selectedCategory = c,
        error => this.errorMessage = error);

      this.categoryService.getCategoryPath(categoryId)
      .subscribe(categories => {
        this.selectedTree = categories;
        this.selectedRootCategory = categories.length > 0 ? categories[categories.length - 1] : null;

        if (this.selectedRootCategory != null) {
        this.dataService.getProducts({category: this.selectedRootCategory.name})
        .subscribe(products => this.products = products,
                error => this.errorMessage = error);
        }
      }, error => this.errorMessage = error);
    });
  }

}
