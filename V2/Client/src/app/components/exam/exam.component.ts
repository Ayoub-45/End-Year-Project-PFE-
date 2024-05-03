import { DatePipe, NgFor } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonModule } from '@coreui/angular';
import { Exam } from 'src/app/interfaces/exam';
import { ExamService } from 'src/app/services/exam/exam.service';
import { DoctorService } from 'src/app/services/doctor/doctor-service.service';
import { Doctor } from 'src/app/interfaces/doctor';
import { RelatedDoctorComponent } from 'src/app/components/related-doctor/related-doctor.component';
@Component({
  selector: 'app-exam',
  standalone: true,
  imports: [
    NgFor,
    DatePipe,
    ButtonModule,
    RouterModule,
    RelatedDoctorComponent,
  ],
  templateUrl: './exam.component.html',
  styleUrl: './exam.component.scss',
})
export class ExamComponent {
  Examens!: Exam[];
  Doctors!: Doctor[];
  @Input() idPatient!: number;

  constructor(private examService: ExamService) {
    this.getExamsOfRelatedPatient(this.idPatient);
  }
  getExamsOfRelatedPatient(id: number) {
    this.examService.fetchData().then((response: any) => {
      this.Examens = response as Exam[];
    });
  }
}
