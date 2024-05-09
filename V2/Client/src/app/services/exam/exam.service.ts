import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Exam } from 'src/app/interfaces/exam';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ExamService {
  url: string = environment.apiBaseUrl + '/Examen';
  constructor(private http: HttpClient) {
    this.fetchData();
  }
  async fetchData(): Promise<Exam> {
    const data = await fetch(this.url);
    return data.json() ?? {};
  }
  async fetchDataById(id: number): Promise<Exam> {
    const data = await fetch(`${this.url}/${id}`);
    return data.json() ?? {};
  }
  async addData(examen: Exam) {
    console.log(examen);
    try {
      const response = await fetch(this.url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(examen),
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
      return responseData as Exam;
    } catch (error) {
      return error instanceof Error ? error.message : 'Unknown error occurred';
    }
  }
}
