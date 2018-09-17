import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsGeneralComponent } from './product-details-general.component';

describe('ProductDetailsGeneralComponent', () => {
  let component: ProductDetailsGeneralComponent;
  let fixture: ComponentFixture<ProductDetailsGeneralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductDetailsGeneralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDetailsGeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
