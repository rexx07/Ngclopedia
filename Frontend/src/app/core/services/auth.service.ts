import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, distinctUntilChanged, map, Observable, ReplaySubject, tap} from "rxjs";
import {ApiService} from "./api.service";
import {JwtService} from "./jwt.service";
import {LoginRequest} from "../models/login-request.model";
import {User} from "../models/user.model";
import {RegisterRequest} from "../models/register-request.model";
import {Router} from "@angular/router";
import {LoginResult} from "../models/login-result.model";

@Injectable()
export class AuthService{
  private currentUserSubject = new BehaviorSubject<LoginResult>({} as LoginResult);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(
    private apiService: ApiService,
    private router: Router,
    private http: HttpClient,
    private jwtService: JwtService
  ) {}

  // Verify JWT in localstorage with server & load user info, it runs once at app startup
  populate(){
    if(this.jwtService.getTokenSession() || this.jwtService.getTokenLocal()){
      this.apiService.get('/user')
        .subscribe(
          data => this.setAuth(data.user),
          err => this.logout()
        );
    } else{
      // Remove any potential remnants of previous auth states
      this.logout();
    }
  }

  setAuth(user: LoginResult): void {
    // Save the jwt sent from server in localstorage
    if(user.rememberMe){
      this.jwtService.saveTokenLocal(user.token)
    } else {
      this.jwtService.saveTokenSession(user.token);
    }
    // Set current user data into observable
    this.currentUserSubject.next(user)
    // Set isAuthenticated to true
    this.isAuthenticatedSubject.next(true);
  }

  logout(): void {
    // Remove JWT from localstorage
    this.jwtService.destroyToken();
    // Set current User to an empty subject
    this.currentUserSubject.next({} as LoginResult)
    // Set auth to false
    this.isAuthenticatedSubject.next(false);
  }

  login(credentials: LoginRequest): Observable<LoginResult>{
    return this.apiService.post('/login', {user: credentials})
      .pipe(map(
        data => {
          this.setAuth(data.user);
          return data;
        }
      ));
  }

  register(data: RegisterRequest): Observable<any> {
    return this.apiService.post('/signup', {data});
  }

  getCurrentUser(): LoginResult{
    return this.currentUserSubject.value;
  }

  // Update the user on the server(email, password, etc)
  update(user: any): Observable<User>{
    return this.apiService.put('/user', {user})
      .pipe(map(
        data => {
          // Update the current user
          this.currentUserSubject.next(data.user);
          return data.user
        }
      ))
  }
}
