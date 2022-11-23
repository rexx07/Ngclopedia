import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, take } from "rxjs";
import { AuthService } from "../core";
import {UserService} from "../core/services/user.service";

@Injectable()
export class AdminDashboardResolver implements Resolve<boolean> {
  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService
  ){}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean>{
    return this.authService.isAuthenticated.pipe(take(1));
  }
}
