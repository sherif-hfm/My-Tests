import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { Comp1Component } from '../comp1/comp1.component';
import { Comp2Component } from '../comp2/comp2.component';
import { App3Component } from '../app3/app3.component';

const heroesRoutes: Routes = [
  { 
    path: '',
  component: App3Component,
  children:[
    {path:'comp1',component:Comp1Component },
    {path:'comp2/:id',component:Comp2Component}
]}
];

@NgModule({imports: [CommonModule,RouterModule.forChild(heroesRoutes)],
  declarations: [],
  exports: [RouterModule]
})
export class App3RouteModule { }
