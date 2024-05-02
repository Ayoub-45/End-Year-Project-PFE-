import { DatePipe, NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Patient } from 'src/app/interfaces/patient';
import { PatientService } from 'src/app/services/patient/patient-service.service';
import { ExamComponent } from 'src/app/components/exam/exam.component';
import { Exam } from 'src/app/interfaces/exam';
@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [DatePipe, NgFor, ExamComponent],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.scss',
})
export class PatientDashboardComponent implements OnInit {
  patient!: Patient;
  id!: number;
  Examens!: Exam[];
  constructor(private route: ActivatedRoute, private service: PatientService) {
    this.getPatientById(this.id).then((response: any) => {
      const p = response;
      this.patient = p[0];
    });
  }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = params['id']; // Access the 'id' parameter from the URL
    });
  }
  async getPatientById(id: number) {
    const patients = await this.service.fetchData();
    return patients.filter((p) => p.id !== id);
  }
}
