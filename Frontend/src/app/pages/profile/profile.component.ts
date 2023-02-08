import {Component} from '@angular/core';
import {AppUser} from '../../data/AppUser';
import {UserService} from '../../core/services/appuser.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class BlogpostComponent {
  public User: AppUser = {
    Username: "",
    Email: "",
    sex: "",
  };

  constructor( private readonly userService: UserService) {
  }
  ngOnInit() {
    this.GetProfile();
  }

  GetProfile() {
    this.userService.getProfile().subscribe(data => {
      this.User = data;
    });
  }
}
