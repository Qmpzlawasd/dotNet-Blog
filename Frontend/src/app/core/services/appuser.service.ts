import {Injectable} from '@angular/core';
import {Observable, tap} from 'rxjs';
import {AppUser} from '../../data/AppUser';
import {ApiService} from './api.service';
import {ActivatedRoute} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public UserId = "";

  constructor(private readonly route: ActivatedRoute, private readonly _apiService: ApiService) {
  }
  getProfile(): Observable<AppUser> {
    this.route.params.subscribe(params => {
      console.log(params);
      this.UserId = params['id'];
    });
    return this._apiService.get(this.route + 'info/' + this.UserId);
  }
}
