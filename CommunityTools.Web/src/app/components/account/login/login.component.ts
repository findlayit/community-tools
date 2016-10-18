import { Component, Input, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { UserService } from '../../../services'
// interfaces
import { ILoginRequest, IAuthenticationModel  } from '../../../interfaces';


@Component({
  selector: 'login',
  providers: [],
  directives: [],
  pipes: [],
  styleUrls: [],
  templateUrl: './login.template.html'
})
export class Login {
  private loginRequest: ILoginRequest;
  private isLoggedIn: boolean;

  constructor(public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    var that = this;
    this.loginRequest = new ILoginRequest();

    this.isLoggedIn = false;
    this.userService.signedIn$.subscribe(data => {
      that.isLoggedIn = data;
    });
  }

  ngOnInit() {
  }
  signIn() {
    var that = this;
    this.userService.Login(this.loginRequest).subscribe(data => {
      var stringData = JSON.stringify(data);
      localStorage.setItem('auth', stringData);
      that.loginRequest = new ILoginRequest();
      that.userService.updateSignedIn(true);
    });
  }
  getAuthModel(): IAuthenticationModel {
    return JSON.parse(localStorage.getItem('auth'));
  }
}
