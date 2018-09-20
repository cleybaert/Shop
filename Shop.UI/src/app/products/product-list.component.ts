import { Component, OnInit } from '@angular/core';
import { IProduct } from '../core/entities/product';
import { DataService } from '../core/services/data.service';
import { ActivatedRoute, RouterLink, Router } from '@angular/router';
import { Category } from '../core/entities/category';
import { CategoryService } from '../core/services/category.service';
import { Tag } from '../core/entities/tag';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public selectedRootCategory: Category;
  public selectedCategory: Category;
  public selectedTree: Category[] = [];
  public tags: Tag[] = [];
  products: IProduct[];
  categories: Category[] = [];
  errorMessage: string;

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private router: Router) { }

  ngOnInit() {
    this.categoryService.getCategories()
      .subscribe(categories => this.categories = categories,
                  error => this.errorMessage = error);

    this.route.queryParams.subscribe((params: any) => {
      const categoryId = params.category;

      this.categoryService.getCategory(categoryId).subscribe(c => {
        this.selectedCategory = c;
        if (this.selectedCategory != null) {
          this.dataService.getProducts({category: this.selectedCategory.name})
          .subscribe(products => this.products = products,
                  error => this.errorMessage = error);
        }        
      }, error => this.errorMessage = error);

      this.categoryService.getTags(categoryId)
      .subscribe(tags => this.tags = tags,
              error => this.errorMessage = error);

      this.categoryService.getCategoryPath(categoryId)
      .subscribe(categories => {
        this.selectedTree = categories;
        this.selectedRootCategory = categories.length > 0 ? categories[0] : null;
      }, error => this.errorMessage = error);
    });
  }

  tagClick(key: string, value: string){
    this.router.navigate(['/products'], { queryParams: { [key]: value}, queryParamsHandling: "merge" })
  }

}
