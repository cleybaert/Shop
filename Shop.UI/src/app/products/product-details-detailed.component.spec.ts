import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsDetailedComponent } from './product-details-detailed.component';

describe('ProductDetailsDetailedComponent', () => {
  let component: ProductDetailsDetailedComponent;
  let fixture: ComponentFixture<ProductDetailsDetailedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductDetailsDetailedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDetailsDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
