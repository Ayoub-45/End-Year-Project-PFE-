import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Specialite } from 'src/app/interfaces/specialite';
@Injectable({
  providedIn: 'root',
})
export class SpecialiteService {
  url: string = environment.apiBaseUrl + '/Specialite';
  constructor(private httpClient: HttpClient) {
    this.fetchData();
  }
  async fetchData() {
    const data = await fetch(this.url);
    return data.json() ?? {};
  }
  async fetchDataById(id: number) {
    const data = await fetch(`${this.url}/${id}`);
    return data.json() ?? {};
  }
  async addSpecialite(specialite: Specialite) {
    try {
      const response = await fetch(this.url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(specialite),
      });

      if (!response.ok) {
        console.error(
          'Network response was not ok. Status code:',
          response.status
        );
        const responseBody = await response.text(); // or response.json() if the response is JSON
        console.error(
          'Network response was not ok. Response body:',
          responseBody
        );
        throw new Error('Network response was not ok');
      }

      const responseData = await response.json();
      return responseData as Specialite;
    } catch (error) {
      return error instanceof Error ? error.message : 'Unknown error occurred';
    }
  }
}
