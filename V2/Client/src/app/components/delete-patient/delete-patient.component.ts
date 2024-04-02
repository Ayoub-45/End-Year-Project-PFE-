import { Component } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-delete-patient',
  templateUrl: './delete-patient.component.html',
  styleUrls: ['./delete-patient.component.css'],
  imports: [ReactiveFormsModule],
})
export class DeletePatientComponent {
  patientId!: number;
  applyForm = new FormGroup({
    id: new FormControl(0),
  });
  constructor(private patientService: PatientService) {}

  async submitApplication() {
    const response = await this.patientService.deletePatient(
      this.applyForm.value.id ?? 0
    );
    if (response) {
      console.log(response);
      alert('Patient deleted successfully');
    }
  }
}
