import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../core/services/auth.service";
import {ErrorsModel} from "../core/models/errors.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pages-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  errors: ErrorsModel = {errors: {}};
  isSubmitting = false;
  isSuccessful = false;
  isSignUpFailed = false;

  usernameCtrl: FormControl;
  passwordCtrl: FormControl;
  confirmPasswordCtrl: FormControl
  firstNameCtrl: FormControl;
  lastNameCtrl: FormControl;
  emailCtrl: FormControl;
  phoneNumberCtrl: FormControl;
  termsAndConditionsCtrl: FormControl;

  registerForm : FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) {
    // use Formbuilder to create form group
    this.usernameCtrl = fb.control('');
    this.passwordCtrl = fb.control('');
    this.confirmPasswordCtrl = fb.control('');
    this.firstNameCtrl = fb.control('');
    this.lastNameCtrl = fb.control('');
    this.emailCtrl = fb.control('');
    this.phoneNumberCtrl = fb.control('');
    this.termsAndConditionsCtrl = fb.control(false);


    this.registerForm = this.fb.group({
      'username': [this.usernameCtrl, Validators.required],
      'password': [this.passwordCtrl, Validators.required],
      'confirmPassword': [this.confirmPasswordCtrl, Validators.required],
      'firstName': [this.firstNameCtrl, Validators.required],
      'lastName': [this.lastNameCtrl, Validators.required],
      'email': [this.emailCtrl, Validators.required],
      'phoneNumber': [this.phoneNumberCtrl, Validators.required],
      'termsANdConditions': [this.termsAndConditionsCtrl]
    });
  }

  ngOnInit(): void {
  }

  onCheckBoxChange(e: any): void{
    if(e.target.checked)
      this.termsAndConditionsCtrl = this.fb.control(true);
  }

  onSubmit(): void{
    this.isSubmitting = true;
    this.errors = {errors: {}};

    const registrationData = this.registerForm.value;
    this.authService.register(registrationData)
      .subscribe(
        data => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
          this.router.navigateByUrl('/login')
        },
        err => {
          this.errors = err;
          this.isSubmitting = false;
          this.isSignUpFailed = true;
        }
      )
  }
}
