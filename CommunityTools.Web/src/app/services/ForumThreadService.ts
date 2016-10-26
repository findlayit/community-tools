import {Injectable, EventEmitter} from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import {AppSettings} from '../config/appSettings';
// Interfaces
import { IForumThread } from '../interfaces';

@Injectable()
export class ForumThreadService {

  constructor(public http: Http, public appSettings: AppSettings) {

  }
  FindAll(): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumthreads', { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindById(id: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumthreads/' + id, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindByUrl(forumUrlName: string, urlName: string): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumthreads/findbyurl/' + forumUrlName + '/' + urlName, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());

  }
  FindByForumId(forumId: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumthreads/findbyforumid/' + forumId, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindByForumUrl(urlName: string): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumthreads/findbyforumurl/' + urlName, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  Add(entity: IForumThread): Observable<any> {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    var params = JSON.stringify(entity);
    return this.http.post(this.appSettings.ProxyApiUrl() + '/forumthreads', params, { withCredentials: true, headers: headers });

  }

  handleError(error: Response) {
    console.error("ForumGroupService error: HTTP status " + error.status);
    return Observable.throw(error.json() || 'Server error: ForumGroupService');
  }
}
