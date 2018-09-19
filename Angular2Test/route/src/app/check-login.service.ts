import { Injectable } from '@angular/core';
import { CanLoad }    from '@angular/router';

@Injectable()
export class CheckLoginService implements CanLoad {

  constructor() { }

canLoad() {
    console.log('CheckLoginService canLoad called');
    var loginStatus = parseInt(localStorage.login);
    if(isNaN(loginStatus))
      loginStatus=0;
      if(loginStatus == 0)
          return false;
      else
          return true;
  }

}
