import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { Comp1Component } from '../comp1/comp1.component';
import { Comp2Component } from '../comp2/comp2.component';
import { App2Component } from '../app2/app2.component';

const heroesRoutes: Routes = [
  { 
    path: '',
  component: App2Component,
  children:[
    {path:'comp1',component:Comp1Component },
    {path:'comp2/:id',component:Comp2Component}
]}
];

@NgModule({
  imports: [CommonModule,RouterModule.forChild(heroesRoutes)],
  declarations: [],
  exports: [RouterModule]
})


export class App2RouteModule {
constructor() { 
  console.log('constructor App2RouteModule');
}  
 }
