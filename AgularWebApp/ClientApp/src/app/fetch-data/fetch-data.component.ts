import { Component, OnInit } from '@angular/core';

import { FetchDataService, NewsStory } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public newsStories: NewsStory[];
  public page: number = 0;
  public loading: boolean;

  constructor(private fetchDataService: FetchDataService) {
  }

  ngOnInit() {
    this.getStories();
  }

  getStories(): void {
    this.loading = true;
    this.fetchDataService.getPagedStories(this.page).toPromise().then(result => {
      this.newsStories = result;
      this.loading = false;
    }).catch(error => {
      this.loading = false;
      console.error(error);
    });
  }

  previous(): void {
    if (this.page > 0) {
      this.page--;
      this.getStories();
    }
  }

  next(): void {
    if (this.page < 49) {
      this.page++;
      this.getStories();
    }
  }

  setPage(page: number): void {

    if (page >= 0 && page <= 49) {
      this.page = page;
      this.getStories();
    }
  }
}

