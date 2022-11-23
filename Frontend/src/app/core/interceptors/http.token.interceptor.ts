import {Injectable} from "@angular/core";
import {
  HTTP_INTERCEPTORS,
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from "@angular/common/http";
import {JwtService} from "../services/jwt.service";
import {EventBusService} from "../event/event-bus.service";
import {catchError, Observable, throwError} from "rxjs";
import {AuthService} from "../services/auth.service";
import {EventData} from "../event/event.class";

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor{
  private isRefreshing = false;

  constructor(
    private jwtService: JwtService,
    private authService: AuthService,
    private eventBusService: EventBusService
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      withCredentials: true,
    });

    return next.handle(req).pipe(
      catchError((error) => {
        if(
          error instanceof HttpErrorResponse
          && req.url.includes('auth/signin')
          && error.status === 401
        ){
          return this.handle401Error(req, next);
        }

        return throwError(() => error);
      })
    );
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler){
    if(!this.isRefreshing){
      this.isRefreshing = true;

      if(this.authService.isAuthenticated){
        this.eventBusService.emit(new EventData('logout', null));
      }
    }

    return next.handle(request);
  }
}

export const httpInterceptorProviders = [
  {provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true},
]
