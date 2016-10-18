export class IAuthenticationModel {
  UserId: number;
  UserName: string;
  Firstname: string;
  Lastname: string;
  Email: string;
  Roles: string;
  AccessToken: string;

  constructor() {
    this.UserId = 0;
    this.UserName = '';
    this.Firstname = '';
    this.Lastname = '';
    this.Email = '';
    this.Roles = '';
    this.AccessToken = '';
  }
}
