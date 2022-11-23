import {Injectable} from "@angular/core";
import {ApiService} from "./api.service";
import {AuthService} from "./auth.service";

@Injectable()
export class UserService{
  constructor(
    private apiService: ApiService,
    private authService: AuthService
  ) {}

}
