import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {UserToken} from '../../share/models/User.model';
import {map} from 'rxjs/operators';
import jwt_decode from 'jwt-decode';
import {isNotNullOrUndefined} from 'codelyzer/util/isNotNullOrUndefined';
import {UserService} from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = 'account/';

  constructor(private http: HttpClient,
              private userService: UserService) {
  }

  login(loginCredentials: { Email: string, Password: string }): Observable<boolean> {
    return this.http.post(this.url + 'login', loginCredentials, {responseType: 'text'})
      .pipe(
        map((token) => {
          if (token) {
            window.localStorage.setItem('api-key', token);
          }
          return true;
        })
      );
  }

  register(registerCredentials: { Email: string, Password: string, FirstName: string, SecondName: string, Nationality: string }): Observable<boolean> {
    return this.http.post(this.url + 'register', registerCredentials)
      .pipe(
        map((response) => true)
      );
  }

  isLogged(): boolean {
    if (this.userService.TokenUser) {
      return true;
    }
    return false;
  }

  isManager(): boolean {
    if (+(this.userService.TokenUser.RoleId) >= 2) {
      return true;
    }
    return false;
  }

  isAdmin(): boolean {
    if (+(this.userService.TokenUser.RoleId) === 3) {
      return true;
    }
    return false;
  }

  decodeToken(token: string = window.localStorage.getItem('api-key')): UserToken | null {
    if (!isNotNullOrUndefined(token)) {
      return null;
    }

    try {
      const decoded = jwt_decode(token) as UserToken;
      this.userService.TokenUser = decoded;
      return decoded;
    } catch (Error) {
      return null;
    }
  }

}
