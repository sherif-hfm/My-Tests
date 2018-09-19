import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { RouteModule } from './app/route-module/route.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

//platformBrowserDynamic().bootstrapModule(RouteModule);
platformBrowserDynamic().bootstrapModule(AppModule);
