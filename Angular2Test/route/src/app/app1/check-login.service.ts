import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot,  RouterStateSnapshot,  CanActivateChild }    from '@angular/router';

@Injectable()
export class CheckLoginService2 implements CanActivate {

  constructor(private router: Router) { }

canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log('CheckLoginService2 canActivate called');
    let url: string = state.url;
    console.log('url ' + url);
    var loginStatus = parseInt(localStorage.login);
    if(isNaN(loginStatus))
      loginStatus=0;
      if(loginStatus == 0)
          return false;
      else
          return true;
  }

}
