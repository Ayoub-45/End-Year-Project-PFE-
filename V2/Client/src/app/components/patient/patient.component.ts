import { Component } from '@angular/core';
import { GetAllpatientsComponent } from '../get-delete-allpatients/get-allpatients.component';
@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [GetAllpatientsComponent],
  templateUrl: './patient.component.html',
  styleUrl: './patient.component.scss',
})
export class PatientComponent {}
