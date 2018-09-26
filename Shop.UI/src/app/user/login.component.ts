import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;
  errorMessage = '';
  private returnUrl: string;

  constructor(
    private router: Router,
    private userService: UserService,
    private route: ActivatedRoute,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.loginForm = this.fb.group({
      userName: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]]
    });
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]],
      repeatPassword: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  onLogin() {
    console.warn(this.loginForm.value);

    const errstr = 'Failed to login: please provide valid e-mail and password';
    const logstr = 'Login: Failed to login due to invalid e-mail or password provided';

    if (this.loginForm && this.loginForm.valid) {
      this.userService.login(this.loginForm.get('userName').value, this.loginForm.get('password').value)
        .subscribe(success => {
          if (success) {
            console.log('Login: Login succeeded');
            console.log('Login: Get user details');
            this.userService.getUserDetails().subscribe(
              user => {
                this.router.navigate([this.returnUrl]);
              }, error => console.log('Login: Failed to get user details')
            );
          } else {
            console.error(logstr);
            this.errorMessage = errstr;
          }
        }, error => {
          console.error(logstr);
          this.errorMessage = errstr;
        });
    } else {
      // stop here if form is invalid
      console.log(logstr);
      this.errorMessage = errstr;
    }
  }

  onRegister() {
    console.log(this.registerForm.value);

    if (this.registerForm && this.registerForm.valid) {
      this.userService.register(
        this.registerForm.get('firstName').value,
        this.registerForm.get('lastName').value,
        this.registerForm.get('email').value,
        this.registerForm.get('password').value)
        .subscribe(success => {
          if (success) {
            this.router.navigate([this.returnUrl]);
          }
        }, error => this.errorMessage = 'Failed to login');
    } else {
      // stop here if form is invalid
      console.log('Login: Invalid user name or password provided');
      this.errorMessage = 'Please provide a valid user name and password.';
    }
  }
}
