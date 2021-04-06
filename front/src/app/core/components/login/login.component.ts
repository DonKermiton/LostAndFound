import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import jwt_decode from 'jwt-decode';
import {UserService} from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  LoginForm: FormGroup;

  constructor(public authService: AuthService,
              public userService: UserService) {
  }

  ngOnInit(): void {
    this.initForm();
    this.authService.decodeToken();
  }

  onSubmit(): void {
    this.controlFormError('Email');
    this.authService.login({
      Email: this.controlFormValue('Email'),
      Password: this.controlFormValue('Password')
    })
      .subscribe((value) => {
        console.log(value);
      }, err => {
        console.log(err);
      });
  }

  controlFormError(control: 'Email' | 'Password'): boolean {
    const controlRef = this.LoginForm.get(control);
    return controlRef.invalid && controlRef.touched;
  }

  private controlFormValue(control: 'Email' | 'Password'): string {
    return this.LoginForm.get(control).value;
  }

  private initForm(): void {
    this.LoginForm = new FormGroup({
      Email: new FormControl(null, [Validators.required, Validators.email]),
      Password: new FormControl(null, [Validators.required])
    });
  }
}
