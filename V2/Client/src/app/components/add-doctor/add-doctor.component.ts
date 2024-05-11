import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Doctor } from 'src/app/interfaces/doctor';
import { Specialite } from 'src/app/interfaces/specialite';
import { SpecialiteService } from 'src/app/services/specialite/specialite.service';

@Component({
  selector: 'app-add-doctor',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor],
  templateUrl: './add-doctor.component.html',
  styleUrl: './add-doctor.component.scss',
})
export class AddDoctorComponent {
  doctorForm!: FormGroup;
  specialites!: Specialite[];

  constructor(
    private fb: FormBuilder,
    private specialiteService: SpecialiteService
  ) {
    this.specialiteService.fetchData().then((res) => {
      this.specialites = res;
      console.log(this.specialites);
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
      const doctor: Doctor = this.doctorForm.value;
      console.log(doctor);
      // You can handle further actions like sending the doctor object to a backend service
    } else {
      // Form is invalid, handle accordingly
    }
  }
}
