import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class PathologieService {
  private url: string = environment.apiBaseUrl + '/Pathologie';

  constructor(private httpClient: HttpClient) {
    this.fetchData();
  }
  async fetchData() {
    const data = fetch(this.url);
    return (await data).json() ?? {};
  }
}
