import { Component } from '@angular/core';
import { AddPatientdetailsComponent } from '../add-patient/add-patientdetails.component';

@Component({
  selector: 'app-patient-mangement',
  standalone: true,
  imports: [AddPatientdetailsComponent],
  templateUrl: './patient-mangement.component.html',
  styleUrl: './patient-mangement.component.css',
})
export class PatientMangementComponent {}
