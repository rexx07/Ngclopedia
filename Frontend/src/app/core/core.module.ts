import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpRequestInterceptor } from './interceptors';

import {
  ApiService,
  AuthGuard, AuthService,
  JwtService,
} from './services';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
    ApiService,
    AuthGuard,
    JwtService,
    AuthService,
  ],
  declarations: []
})
export class CoreModule { }
