import { DatePipe, NgFor } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonModule } from '@coreui/angular';
import { Exam } from 'src/app/interfaces/exam';
import { ExamService } from 'src/app/services/exam/exam.service';
import { RelatedDoctorComponent } from 'src/app/components/related-doctor/related-doctor.component';
import { PathologieComponent } from 'src/app/components/pathologie/pathologie.component';
@Component({
  selector: 'app-exam',
  standalone: true,
  imports: [
    NgFor,
    DatePipe,
    ButtonModule,
    RouterModule,
    RelatedDoctorComponent,
    PathologieComponent,
  ],
  templateUrl: './exam.component.html',
  styleUrl: './exam.component.scss',
})
export class ExamComponent {
  Examens!: Exam[];
  @Input() idPatient!: number;
  constructor(private examService: ExamService) {
    this.getExamsOfRelatedPatient().then((response: any) => {
      this.Examens = response;
    });
  }
  async getExamsOfRelatedPatient() {
    return this.examService.fetchData();
  }
}
