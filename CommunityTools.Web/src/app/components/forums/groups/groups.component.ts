import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { ForumGroupService, UserService } from '../../../services'
// interfaces
import { IForumGroup, IForum, IUser } from '../../../interfaces';
// components
import { LastPost } from '../../shared';


@Component({
  selector: 'groups',
  providers: [ForumGroupService],
  directives: [LastPost],
  pipes: [],
  styleUrls: [],
  templateUrl: './groups.template.html'
})
export class Groups {
  private newGroup: IForumGroup;
  private forumGroups: Array<IForumGroup>;
  private users: Array<IUser>;
  private allowEdit: boolean;

  constructor(public forumGroupService: ForumGroupService, public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    this.newGroup = new IForumGroup();
    var that = this;
    this.allowEdit = this.userService.signedIn;
    this.userService.signedIn$.subscribe(data => {
      that.allowEdit = data;
    });
  }

  ngOnInit() {
    var that = this;
    this.userService.FindAll().subscribe(data => {
      that.users = data;
    });
    this.forumGroupService.FindAll().subscribe(data => {
      that.forumGroups = data;
    });
  }
  viewForums(group: IForumGroup) {
    this.router.navigate(['/forums', group.UrlName]);
  }
  viewForum(group: IForumGroup, forum: IForum) {
    this.router.navigate(['/forums', group.UrlName, forum.UrlName]);
  }
  addGroup() {
    var that = this;
    this.forumGroupService.Add(this.newGroup).subscribe(data => {
      that.newGroup = new IForumGroup();
      that.ngOnInit();
    });
  }
}
