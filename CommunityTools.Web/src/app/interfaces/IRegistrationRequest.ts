export class IRegistrationRequest {
  public UserName: string;
  public Password: string;
  public FirstName: string;
  public LastName: string;
  public RoleName: string;

  constructor(roleName: string) {
    this.UserName = "";
    this.Password = "";
    this.FirstName = "";
    this.LastName = "";
    this.RoleName = roleName;
  }
}
