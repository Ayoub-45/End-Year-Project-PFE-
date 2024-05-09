import { DatePipe, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { Exam } from 'src/app/interfaces/exam';
import { ExamService } from 'src/app/services/exam/exam.service';
import { RelatedDoctorComponent } from '../related-doctor/related-doctor.component';
import { RelatedPatientComponent } from '../related-patient/related-patient.component';
import { PathologieComponent } from '../pathologie/pathologie.component';

@Component({
  selector: 'app-list-examens',
  standalone: true,
  imports: [
    NgFor,
    DatePipe,
    RelatedDoctorComponent,
    RelatedPatientComponent,
    PathologieComponent,
  ],
  templateUrl: './list-examens.component.html',
  styleUrl: './list-examens.component.scss',
})
export class ListExamensComponent {
  exams!: Exam[];
  constructor(private examService: ExamService) {
    this.examService.fetchData().then((response: any) => {
      this.exams = response;
    });
  }
}
