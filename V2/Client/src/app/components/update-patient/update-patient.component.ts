import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../patient';
import { NgFor, TitleCasePipe } from '@angular/common';
@Component({
  selector: 'app-update-patient',
  standalone: true,
  imports: [FormsModule, TitleCasePipe, NgFor],
  templateUrl: './update-patient.component.html',
  styleUrl: './update-patient.component.css',
})
export class UpdatePatientComponent {
  constructor(private service: PatientService) {}
  submitApplication() {
    alert('Patient Updated successuflly successfully');
  }
}
