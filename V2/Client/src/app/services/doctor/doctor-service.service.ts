import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  url: string = environment.apiBaseUrl + '/Medecin';
  constructor(http: HttpClient) {
    this.fetchData();
  }
  async fetchData() {
    const data = await fetch(this.url);
    return data.json() ?? {};
  }
}
