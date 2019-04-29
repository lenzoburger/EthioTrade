import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  avatarUrl = new BehaviorSubject<string>('../../assets/user.png');
  currentAvatarUrl = this.avatarUrl.asObservable();

  constructor(private http: HttpClient) { }

  changeUserPhoto(avatarUrl: string) {
    this.avatarUrl.next(avatarUrl);
  }

  login(userCred: any) {
    return this.http.post(this.baseUrl + 'login', userCred).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.userObject));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.currentUser = user.userObject;
          this.changeUserPhoto(this.currentUser.avatarUrl);
        }
      })
    );
  }

  register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
