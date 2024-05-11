import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ExamService } from 'src/app/services/exam/exam.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Location, NgFor } from '@angular/common';
import { Pathologie } from 'src/app/interfaces/pathologie';
import { PathologieService } from 'src/app/services/pathologie/pathologie.service';
import { Doctor } from 'src/app/interfaces/doctor';
import { DoctorService } from 'src/app/services/doctor/doctor-service.service';
import { Exam } from 'src/app/interfaces/exam';
@Component({
  selector: 'app-add-exam',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule, NgFor],
  templateUrl: './add-exam.component.html',
  styleUrl: './add-exam.component.scss',
})
export class AddExamComponent implements OnInit {
  examForm!: FormGroup;
  pathologies!: Pathologie[];
  doctors!: Doctor[];
  id!: number;
  constructor(
    private formBuilder: FormBuilder,
    private examService: ExamService,
    private pathologieService: PathologieService,
    private doctorService: DoctorService,
    private location: Location,
    private route: ActivatedRoute
  ) {
    this.pathologieService.fetchData().then((response) => {
      this.pathologies = response;
    });
    this.doctorService.fetchData().then((response) => {
      this.doctors = response;
    });
  }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = params['idPatient']; // Access the 'id' parameter from the URL
    });
    this.examForm = this.formBuilder.group({
      idPatient: [this.id, Validators.required],
      pathologie: ['', Validators.required],
      doctor: ['', Validators.required],
      date_Examen: [new Date(), Validators.required],
    });
  }
  onSubmit(event: Event) {
    event.preventDefault();
    if (this.examForm.valid) {
      const doctorName = this.examForm.value.doctor.split(' ');
      const [doctor] = this.doctors.filter(
        (doctor) =>
          doctor.prenom === doctorName[0] && doctor.nom === doctorName[1]
      );
      const pathologieName = this.examForm.value.pathologie;
      const [pathologie] = this.pathologies.filter(
        (pathologie) => pathologie.nom === pathologieName
      );
      const examObject: Exam = {
        id: 0,
        idMedecin: doctor.id,
        idPathologie: pathologie.id,
        idPatient: this.id,
        date_Examen: this.examForm.value.date_Examen,
      };
      this.examService.addData(examObject);
    }
  }
  goback(): void {
    this.location.back();
  }
}
