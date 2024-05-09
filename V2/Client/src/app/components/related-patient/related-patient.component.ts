import { Component, Input } from '@angular/core';
import { Patient } from 'src/app/interfaces/patient';
import { PatientService } from 'src/app/services/patient/patient-service.service';

@Component({
  selector: 'app-related-patient',
  standalone: true,
  imports: [],
  templateUrl: './related-patient.component.html',
  styleUrl: './related-patient.component.scss',
})
export class RelatedPatientComponent {
  @Input() id!: number;
  relatedPatient!: Patient;
  constructor(private patientService: PatientService) {
    this.patientService.fetchData().then((response: any) => {
      this.relatedPatient = response.find((p: Patient) => p.id === this.id);
    });
  }
}
