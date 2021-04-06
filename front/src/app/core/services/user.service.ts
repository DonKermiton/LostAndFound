import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {User, UserToken} from '../../share/models/User.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private LoggedUser = new BehaviorSubject<User>(null);
  private decodedUser: UserToken = null;
  private url = 'user';

  constructor(private http: HttpClient) {
  }

  get loggedUser(): Observable<User> {
    return this.LoggedUser.asObservable();
  }

  get TokenUser(): UserToken {
    return this.decodedUser;
  }

  set TokenUser(userToken) {
    this.decodedUser = userToken;
    this.getLoggedUserCredentials(+this.decodedUser.Id);
  }

  getUserWithSelectedId(Id: number): Observable<User> {
    return this.http.get<User>(`${this.url}/${Id}`);
  }

  private getLoggedUserCredentials(Id: number): void {
    this.getUserWithSelectedId(Id)
      .subscribe((user) => {
        this.LoggedUser.next(user);
      });
  }
}
