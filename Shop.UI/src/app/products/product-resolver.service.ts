import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { IProduct } from '../core/entities/product';
import { DataService } from '../core/services/data.service';

@Injectable({
  providedIn: 'root'
})
export class ProductResolverService implements Resolve<IProduct> {

  constructor(private dataService: DataService,
              private router: Router) { }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any>|Promise<any>|any {
    const id = route.params['id'];
    const basepath = '/products';
    if (isNaN(+id)) {
      console.log(`Product id is not a number: ${id}`);
      this.router.navigate([basepath]);
      return of(null);
    }
    return this.dataService.getProduct(+id)
      .pipe(
        map(product => {
          if (product) {
            return product;
          }
          console.log(`Product was not found: ${id}`);
          this.router.navigate([basepath]);
          return of(null);
          }
        ),
        catchError(error => {
          console.log(`Error while retreiving product: ${error}`);
          this.router.navigate([basepath]);
          return of(null);
          }
        )
      );
  }
}
