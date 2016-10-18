import {Injectable, EventEmitter} from '@angular/core';
import {Http, Response, Headers} from '@angular/http';
import 'rxjs/add/operator/map';
import {Observable, Subject} from 'rxjs/Rx';
// Settings
import {AppSettings} from '../config/appSettings';
// Interfaces
import { IForumPost } from '../interfaces';

@Injectable()
export class ForumPostService {

  constructor(public http: Http, public appSettings: AppSettings) {

  }
  FindAll(): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumposts', { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindById(id: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumposts/' + id, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FindByThreadUrl(forumUrlName: string, threadUrlName: string): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumposts/findbythreadurl/' + forumUrlName + '/' + threadUrlName, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  FetchFullUrl(id: number): Observable<any> {
    return this.http.get(this.appSettings.ProxyApiUrl() + '/forumposts/fullurl/' + id, { withCredentials: true })
      .catch(this.handleError)
      .map(res => res.json());
  }
  Add(entity: IForumPost): Observable<any> {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');

    var params = JSON.stringify(entity);
    return this.http.post(this.appSettings.ProxyApiUrl() + '/forumposts', params, { withCredentials: true, headers: headers })
      .catch(this.handleError);
  }

  handleError(error: Response) {
    console.error("ForumGroupService error: HTTP status " + error.status);
    return Observable.throw(error.json() || 'Server error: ForumGroupService');
  }
}
