/*
 * These are globally available services in any component or any other service
 */

// Angular 2
import { PathLocationStrategy, LocationStrategy } from '@angular/common';
// Angular 2 Http
import { HTTP_PROVIDERS } from '@angular/http';
// Angular 2 Router
import { provideRouter } from '@angular/router';
// Angular 2 forms
import { disableDeprecatedForms, provideForms } from '@angular/forms';


import { routes } from '../app/app.routes';
import { SignedInGuard } from '../app/guards/signedIn.guard';
import { UserService } from '../app/services/UserService';
import { AppSettings, ServiceHelper } from '../app/config';

/*
* Application Providers/Directives/Pipes
* providers/directives/pipes that only live in our browser environment
*/
export const APPLICATION_PROVIDERS = [
  // new Angular 2 forms
  disableDeprecatedForms(),
  provideForms(),

  provideRouter(routes),

  AppSettings,
  ServiceHelper,
  UserService,
  SignedInGuard,

  ...HTTP_PROVIDERS,

  { provide: LocationStrategy, useClass: PathLocationStrategy }
];

export const PROVIDERS = [
  ...APPLICATION_PROVIDERS
];
