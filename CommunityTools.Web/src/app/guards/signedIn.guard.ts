import {Injectable} from '@angular/core';
import {Router, CanActivate} from '@angular/router';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import { AppSettings } from '../config';
// services
import { UserService } from '../services';

@Injectable()
export class SignedInGuard implements CanActivate {
  constructor(public router: Router, public userService: UserService, public appSettings: AppSettings) {

  }
  canActivate() {
    var that = this;
    var url = encodeURIComponent(location.href.split(';')[0]);
    var signedIn = this.userService.isSignedIn();
    var subject = new Subject<boolean>();
    signedIn.subscribe(
      (res) => {
        if (!res) {
          that.router.navigate(['unauthorised', { returnUrl: url }]);
        }
        subject.next(res);
      });
    return subject.asObservable().take(1);
  }
}
