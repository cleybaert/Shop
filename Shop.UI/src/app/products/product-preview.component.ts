import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from '../core/entities/product';

@Component({
  selector: 'app-product-preview',
  templateUrl: './product-preview.component.html',
  styleUrls: ['./product-preview.component.css']
})
export class ProductPreviewComponent implements OnInit {
  @Input('product') product: IProduct;

  constructor() { }

  ngOnInit() {
  }

}
