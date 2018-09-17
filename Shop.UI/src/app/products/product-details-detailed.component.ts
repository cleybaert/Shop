import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../core/entities/product';

@Component({
  selector: 'app-product-details-detailed',
  templateUrl: './product-details-detailed.component.html',
  styleUrls: ['./product-details-detailed.component.css']
})
export class ProductDetailsDetailedComponent implements OnInit {

  product: IProduct;

  constructor(private router: ActivatedRoute) { }

  ngOnInit() {
    this.product = this.router.snapshot.parent.data['product'];
  }

}
