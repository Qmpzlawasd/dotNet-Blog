import {Observable} from 'rxjs';
import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Injectable} from '@angular/core';
import {BlogPost} from '../../data/BlogPost';
import {TopBlogPost} from '../../data/TopBlogPost';
import {ApiService} from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BlogpostService {
  public Id = "";

  constructor(private readonly route: ActivatedRoute, private readonly _apiService: ApiService) {
  }

  getBestPosts(): Observable<Array<TopBlogPost>> {
    return this._apiService.get(this.route + 'GetTopPostsByLikes');
  }

  getPostData(id: string): Observable<BlogPost> {
    return this._apiService.get(this.route + 'GetPostById/' + id);
  }
}
