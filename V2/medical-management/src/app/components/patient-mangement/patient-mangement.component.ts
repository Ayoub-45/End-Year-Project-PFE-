import { Component } from '@angular/core';
import { AddPatientComponent } from '../add-patient/add-patient.component';

@Component({
  selector: 'app-patient-mangement',
  standalone: true,
  imports: [AddPatientComponent],
  templateUrl: './patient-mangement.component.html',
  styleUrl: './patient-mangement.component.css',
})
export class PatientMangementComponent {}
