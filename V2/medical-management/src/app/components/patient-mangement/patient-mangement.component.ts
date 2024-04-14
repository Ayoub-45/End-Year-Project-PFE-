import { Component } from '@angular/core';
import { AddPatientComponent } from '../add-patient/add-patient.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { PatientDetailsComponent } from '../patient-details/patient-details.component';

@Component({
  selector: 'app-patient-mangement',
  standalone: true,
  imports: [
    AddPatientComponent,
    RouterLink,
    RouterLinkActive,
    PatientDetailsComponent,
  ],
  templateUrl: './patient-mangement.component.html',
  styleUrl: './patient-mangement.component.css',
})
export class PatientMangementComponent {}
