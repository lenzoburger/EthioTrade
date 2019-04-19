import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-my-account-edit',
  templateUrl: './my-account-edit.component.html',
  styleUrls: ['./my-account-edit.component.css']
})
export class MyAccountEditComponent implements OnInit {
  @ViewChild('editAccount') editForm: NgForm;
  account: User;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
              private userService: UserService, private authService: AuthService) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.account = data.user;
    });
  }

  updateAccount() {
    this.userService.updateUserDetails(this.authService.decodedToken.nameid, this.account).subscribe(next => {
      this.alertify.success('Account details updated successfully');
      this.editForm.reset(this.account);
    }, error => {
      this.alertify.error(error);
    });
  }
}
