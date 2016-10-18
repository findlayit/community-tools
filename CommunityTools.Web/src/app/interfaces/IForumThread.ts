import { IForum, IForumPost } from './';

export class IForumThread {
  Id: number;
  Title: string;
  UrlName: string;
  ForumId: number;
  Forum: IForum;
  ForumPosts: Array<IForumPost>;
  PostCount: number;
  FirstPost: IForumPost;
  LastPost: IForumPost;

  constructor(forumId: number) {
    this.Id = 0;
    this.Title = "";
    this.UrlName = "";
    this.ForumId = forumId;
    this.Forum = null;
    this.ForumPosts = <Array<IForumPost>>[];
  }
}
