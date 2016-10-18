import { Injectable } from '@angular/core';
import {Headers} from '@angular/http';
import { IAuthenticationModel, ILoginRequest } from '../interfaces'

@Injectable()
export class ServiceHelper {
  GetHeaders(): any {
    var str = localStorage.getItem('auth');
    var auth: IAuthenticationModel = JSON.parse(str);
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    if (auth) {
      headers.append('Authorization', 'Bearer ' + auth.AccessToken);
    } else {
      headers.append('Authorization', 'Bearer ');
    }

    return headers;
  }
}
