import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-my-account-edit',
  templateUrl: './my-account-edit.component.html',
  styleUrls: ['./my-account-edit.component.css']
})
export class MyAccountEditComponent implements OnInit {
  account: User;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.account = data.user;
    });
  }

}
