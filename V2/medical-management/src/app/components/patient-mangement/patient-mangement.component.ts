import { Component } from '@angular/core';
import { AddPatientComponent } from '../add-patient/add-patient.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { PatientDetailsComponent } from '../patient-details/patient-details.component';
import { PatientService } from '../../services/patient.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patient-mangement',
  standalone: true,
  imports: [
    AddPatientComponent,
    RouterLink,
    RouterLinkActive,
    PatientDetailsComponent,
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './patient-mangement.component.html',
  styleUrl: './patient-mangement.component.css',
})
export class PatientMangementComponent {
  show!: Boolean;
  applyForm = new FormGroup({
    id: new FormControl(0),
  });

  constructor(private patientService: PatientService) {}
  async deletePatient() {
    const response = await this.patientService.deletePatient(
      this.applyForm.value.id ?? 0
    );
    if (response) {
      console.log(response);
      alert('Patient deleted successfully, Refresh the browser!');
    }
  }
  setShow() {
    this.show = !this.show;
  }
}
