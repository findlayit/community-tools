import {Injectable, EventEmitter} from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import {AppSettings, ServiceHelper} from '../config';
// Services
import { UserService } from './';
// Interfaces
import { IUser } from '../interfaces'
// import {IUserSurveyQuestion} from '../interfaces/IUserSurveyQuestion';

@Injectable()
export class StateService {
  private userList: Array<IUser>;
  public userList$: any = new EventEmitter();

  constructor(public http: Http, public userService: UserService, public appSettings: AppSettings, public serviceHelper: ServiceHelper) {
  }

  fetchUserList() {
    var that = this;
    this.userService.FindAll().subscribe(data => {
      that.updateUserList(data);
    });
  }
  updateUserList(value) {
    this.userList = value;
    this.userList$.emit(value);
  }
}
