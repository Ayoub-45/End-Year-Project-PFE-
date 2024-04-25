import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient-service.service';
import { Patient } from 'src/app/interfaces/patient';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ButtonDirective, ButtonModule } from '@coreui/angular';

import { ActivatedRoute, RouterLink } from '@angular/router';
@Component({
  selector: 'app-edit-patient',
  standalone: true,
  imports: [ButtonDirective, ReactiveFormsModule, ButtonModule],
  templateUrl: './edit-patient.component.html',
  styleUrl: './edit-patient.component.scss',
})
export class EditPatientComponent implements OnInit {
  patient!: Patient;
  patientForm!: FormGroup;
  patientId!: number;
  constructor(
    private fb: FormBuilder,
    private PatientService: PatientService,
    route: ActivatedRoute
  ) {
    // Fetch patient data from service or route parameters here
    route.params.subscribe((params: any) => {
      this.patientId = params['id']; // Access the 'id' parameter from the URL
    });
    this.patient = {
      id: 0,
      code: '',
      nom: '',
      prenom: '',
      sexe: '',
      adresse: '',
      profession: '',
      gs: '',
      rh: 0,
      race: '',
      poids: 0,
      taille: 0,
      statutMatrimonial: '',
      date_Naissance: new Date(),
    };
  }
  ngOnInit(): void {
    this.patientForm = this.fb.group({
      id: [this.patient.id, Validators.required],
      code: [this.patient.code, Validators.required],
      nom: [this.patient.nom, Validators.required],
      prenom: [this.patient.prenom, Validators.required],
      sexe: [this.patient.sexe, Validators.required],
      adresse: [this.patient.adresse, Validators.required],
      profession: [this.patient.profession, Validators.required],
      gs: [this.patient.gs, Validators.required],
      rh: [this.patient.rh, Validators.required],
      race: [this.patient.race, Validators.required],
      poids: [this.patient.poids, Validators.required],
      taille: [this.patient.taille, Validators.required],
      statutMatrimonial: [this.patient.statutMatrimonial, Validators.required],
      date_Naissance: [this.patient.date_Naissance, Validators.required],
    });
  }
  async updatePatient() {
    const updatedPatientData = this.patientForm.value;
    try {
      const response = await this.PatientService.updatePatient(
        this.patientId,
        updatedPatientData
      );
      console.log('Patient successfully updated', response);
    } catch (error) {
      console.error(error);
    }
  }
}
