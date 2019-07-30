import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

export class FetchDataService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getPagedStories(page: number): Observable<NewsStory[]> {
    return this.http.get<any[]>(this.baseUrl + 'api/HackerNews/NewStories?page=' + page);
  }
}


export interface NewsStory {
  by: string;
  descendants: number;
  id: number;
  kids: number[];
  score: number;
  time: Date;
  title: string;
  type: string;
  url: string;
}
