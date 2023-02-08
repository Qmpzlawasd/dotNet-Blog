import {Observable} from 'rxjs';
import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Injectable} from '@angular/core';
import {BlogPost} from '../../data/BlogPost';
import {TopBlogPost} from '../../data/TopBlogPost';
import {BlogpostService} from '../../core/services/blogpost.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class BlogpostComponent {
  public Post: BlogPost = {
    Title: "",
    Text: "",
    Language: "",
    Writer_id: ""
  };
  constructor(private readonly route: ActivatedRoute, private readonly blogpostService: BlogpostService) {
  }
  ngOnInit() {
    this.LoadPost("");
  }

  LoadPost(id: string) {
    this.blogpostService.getPostData(id).subscribe(data => {
      this.Post = data;
    });
  }
}
