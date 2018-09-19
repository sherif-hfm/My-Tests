import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRouteModule } from './app-route/app-route.module';

import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { Comp1Component } from './comp1/comp1.component';
import { LoginComponent } from './login/login.component';

import { CheckLoginService } from './check-login.service';



@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    Comp1Component,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRouteModule
  ],
  providers: [CheckLoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
