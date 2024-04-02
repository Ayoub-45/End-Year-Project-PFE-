import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../patient';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { DatePipe, NgFor, NgIf } from '@angular/common';
import { AddPatientdetailsComponent } from '../add-patientdetails/add-patientdetails.component';
import { UpdatePatientComponent } from '../update-patient/update-patient.component';
import { DeletePatientComponent } from '../delete-patient/delete-patient.component';

@Component({
  selector: 'app-patient-details',
  standalone: true,
  imports: [
    NgFor,
    NgIf,
    AddPatientdetailsComponent,
    DatePipe,
    ReactiveFormsModule,
    UpdatePatientComponent,
    DeletePatientComponent,
  ],
  templateUrl: './patient-details.component.html',
  styleUrl: './patient-details.component.css',
})
export class PatientDetailsComponent {
  show: boolean = false;
  title: string = 'patient details';
  message!: string;
  patient!: Patient;
  patients!: Patient[];
  applyForm = new FormGroup({
    id: new FormControl(0),
  });
  constructor(private service: PatientService) {
    this.service.fetchData().then((response: Patient[]) => {
      this.patients = response;
    });
  }

  submitApplication(): void {
    this.service
      .getPatientById(this.applyForm.value.id ?? 1)
      .then((res: any) => {
        this.patient = res;
        this.show = true;
      });
  }
}
