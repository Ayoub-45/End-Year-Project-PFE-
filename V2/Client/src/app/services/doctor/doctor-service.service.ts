import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Doctor } from 'src/app/interfaces/doctor';
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
  async addData(doctor: Doctor) {
    try {
      const response = await fetch(this.url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(doctor),
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
      return responseData as Doctor;
    } catch (error) {
      return error instanceof Error ? error.message : 'Unknown error occurred';
    }
  }
}
