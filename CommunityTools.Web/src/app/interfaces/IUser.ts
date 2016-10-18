import { IRole } from './';

export class IUser {
  Id: number;
  Username: string;
  Email: string;
  Password: string;
  Salt: string;
  FirstName: string;
  LastName: string;
  Roles: Array<IRole>;
  CreatedBy: number;
}
