export interface User {
  Id: number;
  Email: string;
  FirstName: string;
  LastName: string;
  Nationality: string;
  RoleId: number;
}

export interface UserToken {
  Id: string;
  Name: string;
  Role: string;
  RoleId: string;
  Nationality: string;
}
