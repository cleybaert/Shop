import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../entities/category';
import { tap, catchError } from 'rxjs/operators';
import { Tag } from '../entities/tag';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private baseUrl = 'http://localhost:4377/api';
  private categoriesUrl = this.baseUrl + '/categories';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http
    .get(this.categoriesUrl + '?full=true')
    .pipe(
      tap(data => {
        console.log('getCategories: ' + JSON.stringify(data));
      }),
      catchError(this.handleError)
    );
  }

  getCategory(id: number): Observable<Category> {
    return this.http
    .get(this.categoriesUrl + '/' + id + '?full=true')
    .pipe(
      tap(data => {
        console.log('getCategory: ' + JSON.stringify(data));
      }),
      catchError(this.handleError)
    );
  }

  getCategoryPath(id: number): Observable<Category[]> {
    return this.http
    .get(this.categoriesUrl + '/' + id + '/path')
    .pipe(
      tap(data => {
        console.log('getCategoryPath: ' + JSON.stringify(data));
      }),
      catchError(this.handleError)
    );
  }

  getTags(id: number): Observable<Tag[]> {
    return this.http
    .get(this.categoriesUrl + '/' + id + '/tags')
    .pipe(
      tap(data => {
        console.log('getTags: ' + JSON.stringify(data));
      }),
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
    console.log(`CategoryService: ${message}`);
  }
}
