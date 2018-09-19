import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { App2RouteModule } from './app2-route/app2-route.module';

import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';
import { App2Component } from './app2/app2.component';

@NgModule({
  imports: [CommonModule,App2RouteModule],
  declarations: [Comp1Component, Comp2Component, App2Component]
})
export class App2Module { }
