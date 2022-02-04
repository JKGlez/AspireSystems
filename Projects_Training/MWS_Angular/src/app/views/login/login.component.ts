import { Component, OnInit } from '@angular/core';

import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Router } from '@angular/router';

import { LoginI } from '../../models/login.interface';

import { AuthService } from '../../services/api/Auth/Auth.service'

import { routes } from '../../app.routing'


@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})

export class LoginComponent  implements OnInit{

  errorStatus:boolean = false;

  errorMsg:any  = "Error on login, verify user and password!";

  private readonly TOKEN_NAME = 'Token_Auth';

  loginForm = new FormGroup({
    username : new FormControl('',Validators.required),
    password :new FormControl('',Validators.required)
  });

  property: any;

  constructor( private authService:AuthService, private router:Router){ }

  ngOnInit(): void {
    this.checkLocalStorage();
  }

  checkLocalStorage(){
    if(localStorage.getItem(this.TOKEN_NAME)){
      this.router.navigate(['dashboard']);
    }
  }

  onLogin(form:LoginI){

    // if(this.authService.loginByUsername(form)){
    //   console.log('ok!');
    //   this.router.navigate(['dashboard']);
    // }
    // else{
    //   console.log('not ok!');
    //   this.errorStatus = true;
    // }

    //this.authService.loginByUsername(form).subscribe(arg => this.property = arg);

    let verifyLogin = this.authService.loginByUsername(form);
    (verifyLogin) ? this.router.navigate(['dashboard']) : this.errorStatus = true;
  }
}
