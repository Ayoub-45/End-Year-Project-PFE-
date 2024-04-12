import { Component } from '@angular/core';
import { AddPatientComponent } from '../add-patient/add-patient.component';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-patient-mangement',
  standalone: true,
  imports: [AddPatientComponent, RouterLink, RouterLinkActive],
  templateUrl: './patient-mangement.component.html',
  styleUrl: './patient-mangement.component.css',
})
export class PatientMangementComponent {}
