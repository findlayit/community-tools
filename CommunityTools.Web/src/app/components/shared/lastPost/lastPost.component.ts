import { Component, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { StateService, ForumPostService } from '../../../services'
// interfaces
import { IUser, IForumPost, IForumThread, IForum } from '../../../interfaces';


@Component({
  selector: 'lastPost',
  providers: [ForumPostService],
  directives: [],
  pipes: [],
  styleUrls: [],
  template: `
            <span *ngIf="dataItem">
              <a href="javascript:void(0)" (click)="navigateLastPost()">by {{getUserName(dataItem.CreatedBy)}}</a> <span>{{dataItem.CreatedDateTime | date:'d MMMM y HH:mm'}}</span>
            </span>
            `
})
export class LastPost {
  @Input() dataItem: IForumPost;

  private users: Array<IUser>;

  constructor(public router: Router, public stateService: StateService, public forumPostService: ForumPostService, public appSettings: AppSettings, public route: ActivatedRoute) {
    var that = this;
    this.stateService.userList$.subscribe(data => {
      that.users = data;
    });
    if (!this.users) {
      this.stateService.fetchUserList();
    }
  }

  ngOnInit() {

  }
  getUserName(id: number) {
    if (this.users) {
      var user: IUser = this.users.filter(o => o.Id == id)[0];
      return user ? user.FirstName + ' ' + user.LastName : '';
    }
    return '';
  }
  navigateLastPost() {
    var that = this;
    this.forumPostService.FetchFullUrl(this.dataItem.Id).subscribe(data => {
      that.router.navigate(['/forums/' + data]);
    });
  }
}
