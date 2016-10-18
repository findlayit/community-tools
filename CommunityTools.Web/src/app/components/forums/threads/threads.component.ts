import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { ForumService, ForumThreadService, UserService } from '../../../services'
// interfaces
import { IForum, IForumThread, IForumPost } from '../../../interfaces';
// Directives
import {TinyMceDirective2} from '../../../directives/tmce.directive'
// components
import { LastPost, FirstPost } from '../../shared';

@Component({
  selector: 'threads',
  providers: [ForumService, ForumThreadService],
  directives: [TinyMceDirective2, LastPost, FirstPost],
  pipes: [],
  styleUrls: [],
  templateUrl: './threads.template.html'
})
export class Threads {
  private groupName: string;
  private forumName: string;
  private forum: IForum;
  private forumThreads: Array<IForumThread>;
  private newThreadVisible: boolean = false;
  private newThread: IForumThread;
  private allowEdit: boolean;

  constructor(public forumService: ForumService, public forumThreadService: ForumThreadService, public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    this.groupName = route.snapshot.params['groupName'];
    this.forumName = route.snapshot.params['forumName'];
    var that = this;

    this.allowEdit = this.userService.signedIn;
    this.userService.signedIn$.subscribe(data => {
      that.allowEdit = data;
    });
  }

  ngOnInit() {
    var that = this;
    this.forumService.FindByUrl(this.forumName).subscribe(data => {
      that.forum = data;
    });
    this.forumThreadService.FindByForumUrl(this.forumName).subscribe(data => {
      that.forumThreads = data;
    });
  }
  viewThread(thread: IForumThread) {
    this.router.navigate(['/forums', this.groupName, this.forumName, thread.UrlName]);
  }
  changeNewThreadVisible(value) {
    // Construct the new object ready for binding
    var _newThread = new IForumThread(this.forum.Id);
    var _newPost = new IForumPost(0);
    _newThread.ForumPosts = [_newPost];
    this.newThread = _newThread;
    // Toggle the value
    this.newThreadVisible = value;
  }
  addThread() {
    var that = this;
    this.forumThreadService.Add(this.newThread).subscribe(data => {
      that.changeNewThreadVisible(false);
      that.ngOnInit();
    });

  }
}
