import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { App3RouteModule } from './app3-route/app3-route.module';

import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';
import { App3Component } from './app3/app3.component';

@NgModule({
  imports: [
    CommonModule,App3RouteModule
  ],
  declarations: [Comp1Component, Comp2Component, App3Component]
})
export class App3Module { }
