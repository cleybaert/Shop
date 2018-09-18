import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list.component';
import { ProductDetailsComponent } from './product-details.component';
import { ProductResolverService } from './product-resolver.service';
import { ProductDetailsGeneralComponent } from './product-details-general.component';
import { ProductDetailsDetailedComponent } from './product-details-detailed.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductPreviewComponent } from './product-preview.component';

const routes: Routes = [
  { path: 'products', component: ProductListComponent},
  { path: 'products/:id',
    component: ProductDetailsComponent,
    resolve: { product: ProductResolverService},
    children: [
      {
        path: '',
        redirectTo: 'general',
        pathMatch: 'full'
      },
      {
        path: 'general',
        component: ProductDetailsGeneralComponent
      },
      {
        path: 'detailed',
        component: ProductDetailsDetailedComponent
      }
    ]}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    RouterModule
  ],
  declarations: [
    ProductDetailsComponent,
    ProductDetailsGeneralComponent,
    ProductDetailsDetailedComponent,
    ProductListComponent,
    ProductPreviewComponent,
  ]
})
export class ProductModule {
}
