import { Component, Input, input } from '@angular/core';
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
  @Input() id!: number;
  doctor!: Doctor;
  constructor(private doctorService: DoctorService) {
    this.doctorService
      .fetchData()
      .then((response) => {
        this.doctor = response.find((d: Doctor) => {
          return d.id === this.id;
        });
      })
      .catch((err) => {
        console.error('Error fetch data');
      });
  }
}
