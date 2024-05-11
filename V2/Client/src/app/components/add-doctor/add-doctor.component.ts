import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { UtilsComponent } from '../utils/utils.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Doctor } from 'src/app/interfaces/doctor';
import { Specialite } from 'src/app/interfaces/specialite';
import { DoctorService } from 'src/app/services/doctor/doctor-service.service';
import { SpecialiteService } from 'src/app/services/specialite/specialite.service';

@Component({
  selector: 'app-add-doctor',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  templateUrl: './add-doctor.component.html',
  styleUrl: './add-doctor.component.scss',
})
export class AddDoctorComponent {
  util = new UtilsComponent();
  doctorForm!: FormGroup;
  specialites!: Specialite[];

  constructor(
    private fb: FormBuilder,
    private specialiteService: SpecialiteService,
    private doctorService: DoctorService
  ) {
    this.specialiteService.fetchData().then((res) => {
      this.specialites = res;
    });
    this.doctorForm = this.fb.group({
      prenom: ['', Validators.required],
      nom: ['', Validators.required],
      specialite: ['', Validators.required],
      grade: ['', Validators.required],
    });
  }
  onSubmit() {
    if (this.doctorForm.valid) {
      const relatedSpecialite = this.specialites.find(
        (speci) => speci.nom === this.doctorForm.value.specialite
      );
      const doctorObj: Doctor = {
        id: 0,
        nom: this.doctorForm.value.nom,
        prenom: this.doctorForm.value.prenom,
        idSpecialite: Number(relatedSpecialite?.id),
        grade: this.doctorForm.value.grade,
      };
      this.doctorService.addData(doctorObj);
      alert('Doctor added successfully!');
      this.util.refresh();
      // You can handle further actions like sending the doctor object to a backend service
    } else {
      throw new Error('Invalid information');
      // Form is invalid, handle accordingly
    }
  }
}
