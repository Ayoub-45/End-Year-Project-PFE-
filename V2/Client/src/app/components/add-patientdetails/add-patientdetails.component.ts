import { Component, input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-add-patientdetails',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-patientdetails.component.html',
  styleUrl: './add-patientdetails.component.css',
})
export class AddPatientdetailsComponent {
  constructor(public service: PatientService) {}
}
