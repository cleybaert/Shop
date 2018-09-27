import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { forbiddenNameValidator } from '../core/validators/size-validator.directive';
import { IProduct } from '../core/entities/product';
import { DataService } from '../core/services/data.service';
import { CartService } from '../core/services/cart.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit, AfterViewInit {

  product: IProduct;
  currentPreview = 0;
  orderForm: FormGroup;

  constructor(
    private router: ActivatedRoute,
    private dataService: DataService,
    private fb: FormBuilder,
    private cartService: CartService) { }

  ngOnInit() {
    this.product = this.router.snapshot.data['product'];
    this.orderForm = this.fb.group({
      quantity: ['0'],
      size: ['null', [forbiddenNameValidator]]
    });
  }

  ngAfterViewInit() {
    this.currentSlide(this.currentPreview);
  }

  onSubmit() {
    const map = new Map().set('size', this.orderForm.get('size').value);
    this.cartService.addToCart(this.product, 1, map);
  }

  currentSlide(selected: number) {
    this.currentPreview = selected;

    const thumbnails = document.getElementsByClassName('thumbnail');
    let i;
    for (i = 0; i < thumbnails.length; i++) {
      thumbnails[i].className = thumbnails[i].className.replace(' active', '');
    }
    if (this.currentPreview < thumbnails.length) {
      thumbnails[this.currentPreview].className += ' active';
    }
  }

  currentSizes(): string[] {
    if (this.product === null) {
      return [];
    }
    if (this.product.tags === null) {
      return [];
    }
    const sizes = this.product.tags.find(tag => tag.key === 'size');
    if (sizes == null) {
      return [];
    } else {
      return sizes.value;
    }
  }

}
