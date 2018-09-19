import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes,PreloadAllModules } from '@angular/router';

import { AppComponent } from '../app.component';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { Comp1Component } from '../comp1/comp1.component';
import { LoginComponent } from '../login/login.component';

import { CheckLoginService } from '../check-login.service';

const appRoutes: Routes = [
  {
    path: 'app',
    component: Comp1Component    
  },
  {
    path: 'login',
    component: LoginComponent    
  },
  {
    path: 'app',
    component: Comp1Component
    , outlet: 'popup',
  },
  {
    path: 'app1',
    loadChildren: 'app/app1/app1.module#App1Module'
    , canLoad: [CheckLoginService]
    ,data: { preload: true }    
  },
  {
    path: 'app2',
    loadChildren: 'app/app2/app2.module#App2Module'
    ,data: { preload: true }
  },
  {
    path: 'app3',
    loadChildren: 'app/app3/app3.module#App3Module',
    data: { preload: true }
  },
  { path: '',   redirectTo: '/app', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [CommonModule,RouterModule.forRoot(appRoutes,{ preloadingStrategy: PreloadAllModules })],
  declarations: [],
  exports: [RouterModule]
})
export class AppRouteModule { }
