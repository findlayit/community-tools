import { IForumPost } from './';

export class IForum {
  Id: number;
  Title: string;
  Description: string;
  UrlName: string;
  ForumGroupId: number;
  ThreadCount: number;
  PostCount: number;
  LastPost: IForumPost;

  constructor(forumGroupId: number) {
    this.Id = 0;
    this.Title = "";
    this.Description = "";
    this.UrlName = "";
    this.ForumGroupId = forumGroupId;
    this.ThreadCount = 0;
    this.PostCount = 0;
    this.LastPost = null;
  }
}
