import { Component, ViewEncapsulation } from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import { Router, RouterConfig } from '@angular/router';

import { AppState } from './app.service';

// Components
import {Unauthorised} from './components/errors/unauthorised/unauthorised.component';
import {TopNav} from './components/navigation/topNav/topNav.component';
// Settings
import {AppSettings, ServiceHelper} from './config';
// services
import { UserService, StateService } from './services';


/*
 * App Component
 * Top Level Component
 */

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  providers: [AppSettings, UserService, ServiceHelper, StateService],
  directives: [TopNav, Unauthorised],
  styleUrls: [
    './app.style.css'
  ],
  template: `
  <topNav></topNav>
  <div class="container-fluid">
    <main>
      <router-outlet></router-outlet>
    </main>
  </div>
  `
})
export class App {
  angularclassLogo = 'assets/img/angularclass-avatar.png';
  name = 'Angular 2 Webpack Starter';
  url = 'https://twitter.com/AngularClass';

  constructor(public appState: AppState, public router: Router, public userService: UserService, public stateService: StateService, public appSettings: AppSettings, public serviceHelper: ServiceHelper) {
  }

  ngOnInit() {
  }

}
