import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../entities/product';
import { tap, catchError, map } from 'rxjs/operators';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Order } from '../entities/order';

@Injectable({providedIn: 'root'})

export class DataService {
  private baseUrl = 'http://localhost:4377/api';
  private productsUrl = this.baseUrl + '/products';
  private categoriesUrl = this.baseUrl + '/categories';
  order: Order;
  products: IProduct[] = [];

  constructor(private http: HttpClient) {
    this.order = new Order();
  }

  getProducts(params?): Observable<IProduct[]> {
    let requestparams = new HttpParams();

    if (params != null) {
      requestparams = requestparams.append('category', params.category);
    }

    return this.http
    .get(this.productsUrl, {params: requestparams})
    .pipe(
      tap(data => {
        console.log('getProducts: ' + JSON.stringify(data));
      }),
      map((products: IProduct[]) => {
        this.products = products;
        return products;
      }),
      catchError(this.handleError)
    );
  }

  getProduct(id: number): Observable<IProduct> {
    const url = `${this.productsUrl}/${id}`;
    return this.http
    .get(url)
    .pipe(
      tap(data => console.log('getProduct: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(error: Response): Observable<any> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    console.error(error);
    return Observable.throw(error.json() || 'Server error');
  }

  log(message: string) {
    console.log(`DataService: ${message}`);
  }
}
