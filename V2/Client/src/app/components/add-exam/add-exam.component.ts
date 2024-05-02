import { Component, Input, input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExamService } from 'src/app/services/exam/exam.service';

@Component({
  selector: 'app-add-exam',
  standalone: true,
  imports: [],
  templateUrl: './add-exam.component.html',
  styleUrl: './add-exam.component.scss',
})
export class AddExamComponent {
  examForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private examService: ExamService
  ) {
    this.examForm = this.formBuilder.group({
      idPatient: ['', Validators.required],
      idPathologie: ['', Validators.required],
      idMedecin: ['', Validators.required],
      date_Examen: [new Date(), Validators.required],
    });
  }
  onSubmit() {
    if (this.examForm.valid) {
      this.examService.addData(this.examForm.value);
    }
  }
}
