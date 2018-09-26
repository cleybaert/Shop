import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (this.userService.loginRequired) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
      return false;
    }
    return true;
  }

  constructor(
    private userService: UserService,
    private router: Router,
  ) { }
}
