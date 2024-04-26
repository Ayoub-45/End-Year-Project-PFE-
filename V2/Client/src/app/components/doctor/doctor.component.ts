import { Component } from '@angular/core';
import { GetAllDoctorsComponent } from '../get-all-doctors/get-all-doctors.component';
@Component({
  selector: 'app-doctor',
  standalone: true,
  imports: [GetAllDoctorsComponent],
  templateUrl: './doctor.component.html',
  styleUrl: './doctor.component.scss',
})
export class DoctorComponent {}
