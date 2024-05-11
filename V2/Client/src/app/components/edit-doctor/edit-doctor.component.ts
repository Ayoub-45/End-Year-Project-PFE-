import { Location, NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Doctor } from 'src/app/interfaces/doctor';
import { Specialite } from 'src/app/interfaces/specialite';
import { DoctorService } from 'src/app/services/doctor/doctor-service.service';
import { SpecialiteService } from 'src/app/services/specialite/specialite.service';

@Component({
  selector: 'app-edit-doctor',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, NgFor],
  templateUrl: './edit-doctor.component.html',
  styleUrl: './edit-doctor.component.scss',
})
export class EditDoctorComponent implements OnInit {
  doctorForm!: FormGroup;
  idDoctor!: number;
  specialites!: Specialite[];
  constructor(
    private fb: FormBuilder,
    private location: Location,
    private router: ActivatedRoute,
    private doctorService: DoctorService,
    private specialteService: SpecialiteService
  ) {
    this.getSpecialites().then((response) => {
      this.specialites = response;
    });
    this.doctorForm = this.fb.group({
      prenom: '',
      nom: '',
      specialite: '',
      grade: '',
    });
  }
  ngOnInit(): void {
    this.router.params.subscribe((params: any) => {
      this.idDoctor = +params['id'];
    });
  }
  async getSpecialites() {
    const response = await this.specialteService.fetchData();
    return response;
  }
  async getDoctor(id: number) {
    const response = (await this.doctorService.fetchData()) as Doctor[];
    const doctor = response.find((doctor) => doctor.id === id);
    return doctor;
  }
  async onSubmit() {
    //Search for specific specialite
    const specialite: any = this.specialites.find(
      (spec) => spec.nom === this.doctorForm.value.specialite
    );
    const doctor = (await this.getDoctor(this.idDoctor)) as Doctor;
    const doctorObj: Partial<Doctor> = {
      id: this.idDoctor,
      prenom: this.doctorForm.value.prenom ?? doctor.prenom,
      idSpecialite: specialite.id ?? doctor.idSpecialite,
      nom: this.doctorForm.value.nom ?? doctor.nom,
      grade: this.doctorForm.value.grade ?? doctor.grade,
    };
    this.doctorService.updateDoctor(this.idDoctor, doctorObj);
  }
  goback(): void {
    this.location.back();
  }
}
