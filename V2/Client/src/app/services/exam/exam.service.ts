import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ExamService {
  url: string = environment.apiBaseUrl + '/Examen';
  constructor(private httpClient: HttpClient) {}
  async fetchData() {
    return (await fetch(this.url)) ?? {};
  }
}
