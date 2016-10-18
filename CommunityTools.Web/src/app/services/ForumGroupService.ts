import {Injectable, EventEmitter} from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import { AppSettings } from '../config/appSettings';
// Interfaces
import { IForumGroup } from '../interfaces';

@Injectable()
export class ForumGroupService {

  constructor(public http: Http, public appSettings: AppSettings) {
  }

  FindAll(): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumgroups', { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindById(id: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumgroups/' + id, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindByUrl(urlName: string): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumgroups/findbyurl/' + urlName, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }

  Add(entity: IForumGroup): Observable<any> {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');

    var params = JSON.stringify(entity);
    return this.http.post(this.appSettings.ProxyApiUrl() + '/forumgroups', params, { withCredentials: true, headers: headers });

  }
  handleError(error: Response) {
    console.error("ForumGroupService error: HTTP status " + error.status);
    return Observable.throw(error.json() || 'Server error: ForumGroupService');
  }
}
