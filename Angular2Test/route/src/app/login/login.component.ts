import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

public loginStatus: number;
  constructor() { }

  ngOnInit() {
    this.loginStatus = parseInt(localStorage.login);
    if(isNaN(this.loginStatus))
      this.loginStatus=0;
    console.log(this.loginStatus);
  }

  login()
  {
    console.log('Login');
    localStorage.setItem("login", "1");
    this.loginStatus=1;
  }

  logout()
  {
    console.log('Logout');
    localStorage.setItem("login", "0");
    this.loginStatus=0;
  }

}
