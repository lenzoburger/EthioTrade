import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from '../_models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  registerForm: FormGroup;

  constructor(private authservice: AuthService, private alertify: AlertifyService,
              private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createRegistrationForm();
  }

  createRegistrationForm() {
    this.registerForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]],
        username: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9-_&\.]*')]],
        password: ['', [Validators.required, Validators.minLength(8),
          Validators.maxLength(20), Validators.pattern('[a-zA-Z 0-9-_&()\*\^%\$#@!+]*')]],
        confirmPassword: ['', Validators.required],
        firstname: ['', [Validators.required, Validators.pattern('[ a-zA-Z-_\.\'’‘]*')]],
        lastname: ['', [Validators.required, Validators.pattern('[ a-zA-Z-_\.\'’‘]*')]],
        dateOfBirth: ['', Validators.required],
        gender: 'male',
        phone: ['', Validators.pattern('[0-9 +]*')],
        country: ['', [Validators.required, Validators.pattern('[a-zA-Z \.-]*')]],
        addressLine1: ['', Validators.pattern('[a-zA-Z 0-9-/\.]*')],
        city: ['', [Validators.required, Validators.pattern('[a-zA-Z \.]*')]],
        region: ['Pick a Region...', Validators.required],
        zipCode: ['', [Validators.pattern('[0-9]*'), Validators.minLength(4)]]
      },
      { validators: this.passwordMatchValidator });
  }

  passwordMatchValidator(form: FormGroup) {
    return form.get('password').value === form.get('confirmPassword').value ? null : { mismatch: true };
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authservice.register(this.user).subscribe(() => {
        this.alertify.success('Registration successful');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.authservice.login(this.user).subscribe(() => {
          this.router.navigate(['/listings']);
        });
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
