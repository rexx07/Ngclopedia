import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, take } from 'rxjs';
import { AuthService } from '../core/services/auth.service';

@Injectable()
export class HomeAuthResolver implements Resolve<boolean>{
  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.authService.isAuthenticated.pipe(take(1));
  }
}
