
import {Observable} from 'rxjs';
import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Injectable} from '@angular/core';
import {BlogPost} from '../../data/BlogPost';
import {TopBlogPost} from '../../data/TopBlogPost';
import {BlogpostService} from '../../core/services/blogpost.service';

@Component({
  templateUrl: './blogpost.component.html',
})
export class BlogpostComponent {
  public Post: TopBlogPost = {
    Id: "",
    Likes: 0
  };
  public Posts: TopBlogPost[] = [];

  constructor(private readonly route: ActivatedRoute, private readonly blogpostService: BlogpostService) {
  }
  ngOnInit() {
    this.blogpostService.getBestPosts().subscribe(data => {
      this.Posts = data;
    });

  }
}
