import { Component } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../interfaces/patient';
import { DatePipe, NgFor } from '@angular/common';

@Component({
  selector: 'app-patient-details',
  standalone: true,
  imports: [NgFor, DatePipe],
  templateUrl: './patient-details.component.html',
  styleUrl: './patient-details.component.css',
})
export class PatientDetailsComponent {
  public patients!: Patient[];
  constructor(private service: PatientService) {
    this.service.fetchData().then((response: Patient[]) => {
      this.patients = response;
    });
  }
}
