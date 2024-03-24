import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { Patient } from '../patient';
@Injectable({
  providedIn: 'root',
})
export class PatientService {
  private url: string = environment.apiBaseUrl + '/Patient';
  public listPatients: Patient[] = [];
  constructor(public http: HttpClient) {
    this.fetchData();
  }
  fetchData(): void {
    this.http.get(this.url).subscribe({
      next: (response) => {
        this.listPatients = response as Patient[];
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
