import { RegisterModel } from './../../_interfaces/user/registerModel.model';
import { AuthenticationService } from './../../shared/services/authentication.service';
import { PasswordConfirmationValidatorService } from './../../shared/services/password-confirmation-validator.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  public isRegistered: boolean = false;

  constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService) { }
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      passwordConfirm: new FormControl(''),
      placeOfWork: new FormControl(''),
      education: new FormControl('')
    });
    this.registerForm.get('passwordConfirm').setValidators([Validators.required,
        this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }
  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public registerUser = (registerFormValue) => {
    this.showError = false;
    const formValues = { ...registerFormValue };
    const user: RegisterModel = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      passwordConfirm: formValues.passwordConfirm,
      placeOfWork: formValues.placeOfWork,
      education: formValues.education
    };
    this._authService.registerUser(user)
    .subscribe(_ => {
      console.log("Successful registration");
      this.isRegistered = true;
    },
    error => {
        this.errorMessage = error;
        this.showError = true;
    })
  }
}