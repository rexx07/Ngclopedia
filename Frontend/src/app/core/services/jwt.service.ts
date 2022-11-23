import { Injectable } from '@angular/core';


@Injectable()
export class JwtService {

  getTokenLocal(): string {
    return window.localStorage['jwtToken'];
  }

  getTokenSession(): string{
    return JSON.parse(window.sessionStorage['jwtToken'])
  }

  saveTokenLocal(token: string): void {
    this.destroyToken();
    window.localStorage['jwtToken'] = token;
  }

  saveTokenSession(token: string): void{
    this.destroyToken();
    window.sessionStorage['jwtToken'] = token;
  }

  destroyToken(): void {
    window.localStorage.removeItem('jwtToken');
    window.sessionStorage.removeItem('jwtToken')
  }

  clearToken(): void{
    window.localStorage.clear();
    window.sessionStorage.clear();
  }

}
