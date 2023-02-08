import {ApiService} from './api.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Category} from '../../data/Category';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private readonly route = 'BlogPost';

  constructor(private readonly _apiService: ApiService) {
  }
  getCategoriesOfPost(): Observable<Array<Category>> {
    return this._apiService.get(this.route + 'GetTags');
  }
}

