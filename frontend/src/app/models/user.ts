export class User {
  public name: string;
  public email: string;
  public phoneNumber: string;

  public constructor(init?: Partial<User>) {
    Object.assign(this, init);
  }
}
