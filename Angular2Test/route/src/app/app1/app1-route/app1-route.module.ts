import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { App1Component } from '../app1/app1.component';
import { Comp1Component } from '../comp1/comp1.component';
import { Comp2Component } from '../comp2/comp2.component';

import { CheckLoginService2 } from '../check-login.service';

const heroesRoutes: Routes = [
  { 
    path: '',
  component: App1Component,
  children:[
    {
      path:'',
      children:[
        {path:'comp1',component:Comp1Component },
        {path:'comp2/:id',component:Comp2Component}]  
    }
]}
];

const heroesRoutes2: Routes = [
  { 
    path: '',
    canActivate:[CheckLoginService2],
  component: App1Component,
  children:[
    {path:'comp1',component:Comp1Component },
        {path:'comp2/:id',component:Comp2Component}
]}
];



@NgModule({
  imports: [CommonModule,RouterModule.forChild(heroesRoutes2)],
  declarations: [],
  exports: [RouterModule]
})


export class App1RouteModule { }
