import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Errors} from "../core/models/errors.model";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../core";
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isLoggedIn = false;
  errors: Errors = {errors: {}};
  isSubmitting = false;
  isLoginFailed = false;

  usernameCtrl: FormControl;
  passwordCtrl: FormControl;
  rememberMeCtrl: FormControl;
  authForm : FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    // use Formbuilder to create form group
    this.usernameCtrl = fb.control('');
    this.passwordCtrl = fb.control('');
    this.rememberMeCtrl = fb.control(false);

    this.authForm = this.fb.group({
      'email': [this.usernameCtrl, Validators.required],
      'password': [this.passwordCtrl, Validators.required],
      'rememberMe': [this.rememberMeCtrl]
    });
  }

  ngOnInit(): void {
    if(this.authService.isAuthenticated){
      this.isLoggedIn = true;
    }
  }

  onCheckBoxChange(e: any): void{
    if(e.target.checked)
      this.rememberMeCtrl = this.fb.control(true);
  }

  onSubmit(): void{
    this.isSubmitting = true;
    this.errors = {errors: {}};

    const credentials = this.authForm.value;
    this.authService.login(credentials)
      .subscribe(
        data => {
          this.router.navigateByUrl('/');
          this.isLoginFailed = false;
        },
        err => {
          this.errors = err.error.message;
          this.isLoginFailed = true;
        }
      );
  }

}
