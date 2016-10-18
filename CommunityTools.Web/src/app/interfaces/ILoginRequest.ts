export class ILoginRequest {
  UserName: string;
  Password: string;

  constructor() {
    this.UserName = '';
    this.Password = '';
  }
}
