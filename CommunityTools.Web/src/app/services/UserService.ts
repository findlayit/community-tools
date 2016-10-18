import {Injectable, EventEmitter} from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import {AppSettings, ServiceHelper} from '../config';
// Interfaces
import { IAuthenticationModel, ILoginRequest, IRegistrationRequest } from '../interfaces'
// import {IUserSurveyQuestion} from '../interfaces/IUserSurveyQuestion';

@Injectable()
export class UserService {
  public signedIn: boolean;
  public signedIn$: any = new EventEmitter();

  constructor(public http: Http, public appSettings: AppSettings, public serviceHelper: ServiceHelper) {
    var that = this;
    this.IsLoggedOn().subscribe(data => {
      that.updateSignedIn(data);
    });
  }

  FindAll(): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/users', { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindById(id: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/users/' + id, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }

  updateSignedIn(value) {
    this.signedIn = value;
    this.signedIn$.emit(value);
  }

  Login(request: ILoginRequest): Observable<any> {
    var headers = this.serviceHelper.GetHeaders();

    var params = JSON.stringify(request);
    return this.http.post(this.appSettings.ProxyApiUrl() + '/auth/login', params, { withCredentials: true, headers: headers })
      .catch(this.handleError)
      .map(res => res.json());
  }
  Logout(): Observable<any> {
    var headers = this.serviceHelper.GetHeaders();

    return this.http.post(this.appSettings.ProxyApiUrl() + '/auth/logout', null, { withCredentials: true, headers: headers })
      .catch(this.handleError)
      .map(res => res.json());
  }
  Register(request: IRegistrationRequest): Observable<any> {
    var headers = this.serviceHelper.GetHeaders();

    var params = JSON.stringify(request);
    return this.http.post(this.appSettings.ProxyApiUrl() + '/auth/register', params, { withCredentials: true, headers: headers })
      .catch(this.handleError)
      .map(res => res.json());
  }

  IsLoggedOn(): Observable<any> {
    var headers = this.serviceHelper.GetHeaders();
    return this.http.get(this.appSettings.ProxyApiUrl() + '/auth/isloggedon', { withCredentials: true, headers: headers })
      .catch(this.handleError)
      .map(res => res.json());
  }
  handleError(error: Response) {
    console.error("UserService error: HTTP status " + error.status);
    return Observable.throw(error.json() || 'Server error: UserService');
  }

  isSignedIn(): Observable<boolean> {
    var that = this;
    var subject = new Subject<boolean>();
    subject.next(this.signedIn);
    this.signedIn$.subscribe(data => {
      subject.next(data)
    });
    return subject.asObservable().take(1);
  }
}
