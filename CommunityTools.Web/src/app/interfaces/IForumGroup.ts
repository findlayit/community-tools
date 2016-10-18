import { IForum } from './';
export class IForumGroup {
  Id: number;
  Title: string;
  UrlName: string;
  Forums: Array<IForum>;

  constructor() {
    this.Id = 0;
    this.Title = '';
    this.UrlName = '';
    this.Forums = null;
  }
}
