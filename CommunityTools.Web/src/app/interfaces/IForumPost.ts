export class IForumPost {
  Id: number;
  Title: string;
  UrlName: string;
  Content: string;
  ForumThreadId: number;

  constructor(forumThreadId: number) {
    this.Id = 0;
    this.Title = "";
    this.UrlName = "";
    this.Content = "";
    this.ForumThreadId = forumThreadId;
  }
}
