import { DatePipe, NgFor } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonDirective, ButtonModule } from '@coreui/angular';
import { Exam } from 'src/app/interfaces/exam';
import { ExamService } from 'src/app/services/exam/exam.service';
import { ButtonsComponent } from 'src/app/views/buttons/buttons/buttons.component';

@Component({
  selector: 'app-exam',
  standalone: true,
  imports: [NgFor, DatePipe, ButtonModule, RouterModule],
  templateUrl: './exam.component.html',
  styleUrl: './exam.component.scss',
})
export class ExamComponent {
  Examens!: Exam[];
  @Input() idPatient!: number;
  constructor(private examService: ExamService) {
    this.getExamsOfRelatedPatient(this.idPatient);
  }
  getExamsOfRelatedPatient(id: number) {
    this.examService.fetchData().then((response: any) => {
      this.Examens = response as Exam[];
      console.log(this.Examens.filter((exam) => exam.idPatient !== id));
    });
  }
}
