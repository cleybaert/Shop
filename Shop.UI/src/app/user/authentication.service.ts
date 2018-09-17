import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient,
    private router: Router) { }

  login(userName: String, password: String): Observable<boolean> {
    const user = {
      username: userName,
      password: password
    };
    return this.http
      .post('http://localhost:4377/api/account', user)
      .pipe(
        map(
          (data: any) => {
            localStorage.setItem('access_token', data.token);
            return true;
          }
        ),
        catchError(err => {
            console.log(err);
            return of(null);
          })
      );
  }

  public get loginRequired(): boolean {
    const token = localStorage.getItem('access_token');
    const helper = new JwtHelperService();

    const res = !(token && !helper.isTokenExpired(token));
    return res;
  }

  logout() {
    localStorage.removeItem('access_token');
  }
}
