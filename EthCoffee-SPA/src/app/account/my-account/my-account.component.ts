import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.css']
})
export class MyAccountComponent implements OnInit {
  account: User;

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userService.changeAvatar = false;
    this.route.data.subscribe(data => {
      this.account = data.user;
    });
  }

  changeAvatar() {
    this.userService.changeAvatar = true;
  }

}
