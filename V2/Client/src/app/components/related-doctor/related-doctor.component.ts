import { Component, Input } from '@angular/core';
import { Doctor } from 'src/app/interfaces/doctor';
import { DoctorService } from 'src/app/services/doctor/doctor-service.service';

@Component({
  selector: 'app-related-doctor',
  standalone: true,
  imports: [],
  templateUrl: './related-doctor.component.html',
  styleUrl: './related-doctor.component.scss',
})
export class RelatedDoctorComponent {
  @Input() idMedecin!: number;
  doctor!: Doctor;
  constructor(private doctorService: DoctorService) {
    this.getRelatedDoctor().then((response: any) => {
      this.doctor = response[0];
    });
  }
  async getRelatedDoctor() {
    return await this.doctorService.fetchData();
  }
}
