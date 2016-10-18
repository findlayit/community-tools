import { Component, Input, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { UserService } from '../../../services'
// interfaces
import { IAuthenticationModel } from '../../../interfaces';


@Component({
  selector: 'topNav',
  providers: [],
  directives: [],
  pipes: [],
  styleUrls: [],
  templateUrl: './topNav.template.html'
})
export class TopNav {
  private isLoggedIn: boolean;

  constructor(public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    var that = this;
    this.isLoggedIn = false;
    this.userService.signedIn$.subscribe(data => {
      that.isLoggedIn = data;
    });
  }

  ngOnInit() {
  }
  private get AuthModel(): IAuthenticationModel {
    return JSON.parse(localStorage.getItem('auth'));
  }
  SignIn() {
    this.router.navigateByUrl('account/login');
  }
  Register() {
    this.router.navigateByUrl('account/register');
  }
  SignOut() {
    var that = this;
    this.userService.Logout().subscribe(data => {
      localStorage.removeItem('auth');
      that.userService.updateSignedIn(false);
    });
  }
}
