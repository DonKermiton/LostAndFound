import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  RegisterForm: FormGroup;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.initForm();
  }

  onSubmit(): void {
    console.log(this.RegisterForm.getRawValue());
    this.authService.register(this.RegisterForm.getRawValue()).subscribe(console.log);
  }

  controlFormError(control: 'Email' | 'Password' | 'FirstName' | 'SecondName' | 'Nationality'): boolean {
    const controlRef = this.RegisterForm.get(control);
    return controlRef.invalid && controlRef.touched;
  }

  private initForm(): void {
    this.RegisterForm = new FormGroup({
      Email: new FormControl(null, [Validators.required, Validators.required]),
      Password: new FormControl(null, [Validators.required]),
      FirstName: new FormControl(null),
      SecondName: new FormControl(null),
      Nationality: new FormControl(null),
    });
  }
}
