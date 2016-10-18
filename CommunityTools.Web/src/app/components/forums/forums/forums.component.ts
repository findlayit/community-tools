import { Component, Input, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { ForumGroupService, ForumService, UserService } from '../../../services'
// interfaces
import { IForumGroup, IForum, IUser } from '../../../interfaces';
// components
import { LastPost } from '../../shared';


@Component({
  selector: 'forums',
  providers: [ForumGroupService, ForumService],
  directives: [LastPost],
  pipes: [],
  styleUrls: [],
  templateUrl: './forums.template.html'
})
export class Forums {
  private groupName: string;
  private forumGroup: IForumGroup;
  private newForum: IForum;
  private newForumVisible: boolean = false;
  private allowEdit: boolean;

  constructor(public forumGroupService: ForumGroupService, public forumService: ForumService, public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    this.groupName = route.snapshot.params['groupName'];
    var that = this;
    this.allowEdit = this.userService.signedIn;
    this.userService.signedIn$.subscribe(data => {
      that.allowEdit = data;
    });
  }

  ngOnInit() {
    var that = this;
    this.forumGroupService.FindByUrl(this.groupName).subscribe(data => {
      that.forumGroup = data;
    });
  }

  viewForum(forum: IForum) {
    this.router.navigate(['/forums', this.groupName, forum.UrlName]);
  }

  changeNewForumVisible(value) {
    // Construct the new object ready for binding
    this.newForum = new IForum(this.forumGroup.Id);
    // Toggle the value
    this.newForumVisible = value;
  }
  addForum() {
    var that = this;
    this.forumService.Add(this.newForum).subscribe(data => {
      that.changeNewForumVisible(false);
      that.ngOnInit();
    });
  }
}
