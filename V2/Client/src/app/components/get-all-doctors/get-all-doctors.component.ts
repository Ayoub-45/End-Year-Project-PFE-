import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { Doctor } from '../../interfaces/doctor';
import { Specialite } from '../../interfaces/specialite';
import { SpecialiteService } from '../../services/specialite/specialite.service';
import { DoctorService } from '../../services/doctor/doctor-service.service';
import { SpecialiteComponent } from '../../components/specialite/specialite.component';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-get-all-doctors',
  standalone: true,
  imports: [NgFor, SpecialiteComponent, RouterModule],
  templateUrl: './get-all-doctors.component.html',
  styleUrl: './get-all-doctors.component.scss',
})
export class GetAllDoctorsComponent {
  doctors!: Doctor[];
  specialites!: Specialite;
  constructor(
    private doctorService: DoctorService,
    private specialteService: SpecialiteService
  ) {
    this.getDoctors().then((response: Doctor[]) => {
      this.doctors = response;
    });
  }
  async getDoctors() {
    return await this.doctorService.fetchData();
  }
  async getSpecialteById(id: number) {
    return await this.specialteService.fetchDataById(id);
  }
  async deleteDoctor(id: number) {}
}
