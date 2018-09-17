import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  private errorMessage: string;
  private returnUrl: string;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.loginForm = this.fb.group({
      userName: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  onSubmit() {
    console.warn(this.loginForm.value);

    if (this.loginForm && this.loginForm.valid) {
      this.authenticationService.login(this.loginForm.get('userName').value, this.loginForm.get('password').value)
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
