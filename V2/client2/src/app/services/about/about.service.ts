import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { About } from '../../interfaces/about';

@Injectable({
  providedIn: 'root',
})
export class AboutService {
  private baseUrl: string = environment.apiBaseUrl + '/About';
  constructor() {}
  async fetchData(): Promise<About> {
    const response = await fetch(this.baseUrl);
    return (await response.json()) ?? {};
  }
}
