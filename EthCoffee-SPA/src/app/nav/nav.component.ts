import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  avatarUrl: string;

  constructor(public authservice: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.authservice.avatarUrl.subscribe(avatarUrl => this.avatarUrl = avatarUrl);
  }

  login() {
    this.authservice.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {

      this.router.navigate(['/listings']);
    });
  }

  loggedIn() {
    return this.authservice.loggedIn();
  }

  logout() {
    if (this.loggedIn()) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      this.authservice.decodedToken = null;
      this.authservice.currentUser = null;
    }
    this.alertify.message('Logged out');
    this.router.navigate(['/home']);
  }
}
