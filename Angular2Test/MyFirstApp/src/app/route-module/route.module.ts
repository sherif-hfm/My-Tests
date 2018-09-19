import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app/app.component';
import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';
import { Comp3Component } from './comp3/comp3.component';
import { ErrorComponent } from './error/error.component';
import { MainComponent } from './main/main.component';


const appRoutes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full'},
  // { path: '', component: MainComponent },  
  { path: 'main', component: MainComponent },  
  { path: 'comp1', component: Comp1Component },  
  { path: 'comp2/:id',      component: Comp2Component },
  {path: 'comp3',component: Comp3Component,data: { title: 'Dom Control' } },  
  { path: '**', component: ErrorComponent } 
];

@NgModule({
  imports: [CommonModule,BrowserModule, RouterModule.forRoot(appRoutes)],
  declarations: [Comp1Component, AppComponent, Comp2Component, Comp3Component, ErrorComponent, MainComponent],
  bootstrap: [AppComponent ]
})
export class RouteModule { }
