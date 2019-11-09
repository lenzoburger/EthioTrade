import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from 'src/app/_services/auth.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Avatar } from 'src/app/_models/avatar';

@Component({
  selector: 'app-my-account-edit',
  templateUrl: './my-account-edit.component.html',
  styleUrls: ['./my-account-edit.component.css']
})
export class MyAccountEditComponent implements OnInit {
  @ViewChild('editAccount') editForm: NgForm;
  account: User;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  hasAnotherDropZoneOver = false;
  baseUrl = environment.apiUrl;
  changeAvatar: boolean;
  avatarUrl: string;
  addressNotNull = false;
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
    this.authService.currentAvatarUrl.subscribe( avatarUrl => this.avatarUrl = avatarUrl);
    this.changeAvatar = this.userService.changeAvatar;
    this.intializerUploader();
    if (this.account.physicalAddress) {
      this.addressNotNull = true;
    }
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  toggleChangeAvatar() {
    this.changeAvatar = !this.changeAvatar;
  }

  updateAccount() {
    this.userService.updateUserDetails(this.authService.decodedToken.nameid, this.account).subscribe(next => {
      this.alertify.success('Account details updated successfully');
      this.editForm.reset(this.account);
    }, error => {
      this.alertify.error(error);
    });
  }

  intializerUploader() {
    this.uploader = new FileUploader({
      url: `${this.baseUrl}/users/${this.authService.decodedToken.nameid}/avatar`,
      authToken: `Bearer ${localStorage.getItem('token')}`,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: Avatar = JSON.parse(response);
        const avatar = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description
        };
        this.account.avatar = avatar;
        this.account.avatarUrl =  avatar.url;
        this.authService.changeUserPhoto(avatar.url);
        this.authService.currentUser.avatarUrl = avatar.url;
        localStorage.setItem('user', JSON.stringify(this.authService.currentUser));
        this.toggleChangeAvatar();
      }
    };
  }


}
