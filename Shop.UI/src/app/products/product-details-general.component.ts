import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../core/entities/product';

@Component({
  selector: 'app-product-details-general',
  templateUrl: './product-details-general.component.html',
  styleUrls: ['./product-details-general.component.css']
})
export class ProductDetailsGeneralComponent implements OnInit {

  product: IProduct;

  constructor(private router: ActivatedRoute) { }

  ngOnInit() {
    this.product = this.router.snapshot.parent.data['product'];
  }

}
