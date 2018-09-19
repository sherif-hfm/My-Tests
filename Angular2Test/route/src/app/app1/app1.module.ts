import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { App1RouteModule } from './app1-route/app1-route.module';
import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';
import { App1Component } from './app1/app1.component';
import { CheckLoginService2 } from './check-login.service';



@NgModule({
  imports: [CommonModule,App1RouteModule ],
  declarations: [Comp1Component, Comp2Component, App1Component],
  providers: [CheckLoginService2],
})
export class App1Module { 

  constructor() { 
  console.log('constructor App1Module');
}  
}
