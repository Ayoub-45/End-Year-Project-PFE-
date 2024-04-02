import { Component, input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../patient';
@Component({
  selector: 'app-add-patientdetails',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-patientdetails.component.html',
  styleUrl: './add-patientdetails.component.css',
})
export class AddPatientdetailsComponent {
  patient!: Patient;
  applyForm = new FormGroup({
    id: new FormControl(0),
    code: new FormControl(''),
    nom: new FormControl(''),
    prenom: new FormControl(''),
    sexe: new FormControl(''),
    gs: new FormControl(''),
    rh: new FormControl(0),
    race: new FormControl(''),
    poids: new FormControl(0),
    taille: new FormControl(0),
    statutMatrimonial: new FormControl(''),
    adresse: new FormControl(''),
    profession: new FormControl(''),
    date_Naissance: new FormControl(''),
  });
  constructor(private service: PatientService) {}
  async submitApplication() {
    const response = await this.service.addPatient(
      this.applyForm.value.id ?? 0,
      this.applyForm.value.code ?? '',
      this.applyForm.value.nom ?? '',
      this.applyForm.value.prenom ?? '',
      this.applyForm.value.sexe ?? '',
      this.applyForm.value.adresse ?? '',
      this.applyForm.value.profession ?? '',
      this.applyForm.value.gs ?? '',
      this.applyForm.value.rh ?? 0,
      this.applyForm.value.race ?? '',
      this.applyForm.value.poids ?? 0,
      this.applyForm.value.taille ?? 0,
      this.applyForm.value.statutMatrimonial ?? '',
      this.applyForm.value.date_Naissance ??
        `${new Date().getMonth()}/${new Date().getMonth()}/${new Date().getFullYear()}/`
    );
    if (response) {
      alert('Patient added successfully');
    }
  }
}
