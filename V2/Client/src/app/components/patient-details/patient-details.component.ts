import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { Patient } from '../../patient';
import { NgModel } from '@angular/forms';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-patient-details',
  standalone: true,
  imports: [NgFor],
  templateUrl: './patient-details.component.html',
  styleUrl: './patient-details.component.css',
})
export class PatientDetailsComponent implements OnInit {
  title = 'paitent details';
  patients: Patient[] = [];
  constructor(public service: PatientService) {}
  ngOnInit(): void {
    this.service.fetchData();
  }
}
