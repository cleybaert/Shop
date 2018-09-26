import { IUser } from './user';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient,
    private router: Router) { }

  login(userName: String, password: String): Observable<boolean> {
    const user = {
      username: userName,
      password: password
    };
    return this.http
      .post('http://localhost:4377/api/accounts/login', user)
      .pipe(
        map(
          (data: any) => {
            localStorage.setItem('access_token', data.token);
            return true;
          }
        ),
        catchError(err => {
            console.error(err);
            return of(null);
          })
      );
  }

  register(firstName: string, lastName: string, email: string, password: string): Observable<boolean> {
    return this.http
      .post('http://localhost:4377/api/accounts/register', { FirstName: firstName, LastName: lastName, Email: email, Password: password })
      .pipe(
        map(
          (data: any) => {
            localStorage.setItem('access_token', data.token);
            return true;
          }
        ),
        catchError(err => {
            console.error(err);
            return of(null);
          })
      );
  }

  getUserDetails(): Observable<IUser> {
    return this.http
      .get('http://localhost:4377/api/accounts')
      .pipe(
        map((user: IUser) => {
          console.log(JSON.stringify(user));
          localStorage.setItem('currentUser', JSON.stringify(user));
        }),
        catchError(err => {
          console.error('Login: Failed to get user details');
          console.error(err);
          return of(null);
        })
      );
  }

  public get loginRequired(): boolean {
    if (this.currentUser === null) {
      return true;
    }
    const token = localStorage.getItem('access_token');
    const helper = new JwtHelperService();

    const res = !(token && !helper.isTokenExpired(token));
    return res;
  }

  public get currentUser(): IUser {
    const str = localStorage.getItem('currentUser');
    if (str) {
      return JSON.parse(str);
    }
    return null;
  }

  getToken(): string {
    return localStorage.getItem('access_token');
  }

  logout() {
    localStorage.removeItem('access_token');
  }
}
