import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { DomSanitizationService } from '@angular/platform-browser';

// Settings
import { AppSettings } from '../../../config/appSettings';
// Services
import { ForumThreadService, ForumPostService, UserService } from '../../../services'
// interfaces
import { IForumThread, IForumPost } from '../../../interfaces';
// Directives
import {TinyMceDirective2} from '../../../directives/tmce.directive'

@Component({
  selector: 'posts',
  providers: [ForumThreadService, ForumPostService, DomSanitizationService],
  directives: [TinyMceDirective2],
  pipes: [],
  styleUrls: [],
  templateUrl: './posts.template.html'
})
export class Posts {
  private groupName: string;
  private forumName: string;
  private threadName: string;
  private forumThread: IForumThread;
  private forumPostList: Array<IForumPost>;
  private newPostVisible: boolean = false;
  private newPost: IForumPost;
  private allowEdit: boolean;

  constructor(private sanitizer: DomSanitizationService, public forumThreadService: ForumThreadService, public forumPostService: ForumPostService, public userService: UserService, public router: Router, public appSettings: AppSettings, public route: ActivatedRoute) {
    this.groupName = route.snapshot.params['groupName'];
    this.forumName = route.snapshot.params['forumName'];
    this.threadName = route.snapshot.params['threadName'];
    var that = this;
    this.allowEdit = this.userService.signedIn;
    this.userService.signedIn$.subscribe(data => {
      that.allowEdit = data;
    });
  }

  ngOnInit() {
    var that = this;
    this.forumThreadService.FindByUrl(this.forumName, this.threadName).subscribe(data => {
      that.forumThread = data;
    });
    this.forumPostService.FindByThreadUrl(this.forumName, this.threadName).subscribe(data => {
      that.forumPostList = data;
    });
  }
  changeNewPostVisible(value: boolean) {
    this.newPost = new IForumPost(this.forumThread.Id);
    this.newPostVisible = value;
  }
  addPost() {
    var that = this;
    this.forumPostService.Add(this.newPost).subscribe(data => {
      that.changeNewPostVisible(false);
      that.ngOnInit();
    });
  }
}
