import { DatePipe, NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { PatientService } from '../../services/patient-service.service';
import { Patient } from 'src/app/interfaces/patient';
import {
  ButtonModule,
  SpinnerComponent,
  ToastComponent,
} from '@coreui/angular';
import { UtilsComponent } from '../utils/utils.component';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-get-allpatients',
  standalone: true,
  imports: [
    DatePipe,
    NgFor,
    ButtonModule,
    UtilsComponent,
    RouterLink,
    RouterLinkActive,
    SpinnerComponent,
    NgIf,
  ],
  templateUrl: './get-allpatients.component.html',
  styleUrl: './get-allpatients.component.scss',
})
export class GetAllpatientsComponent {
  public patients!: Patient[];
  public isLoading!: Boolean;
  private utils = new UtilsComponent();
  constructor(private service: PatientService) {
    service.fetchData().then((response) => {
      this.patients = response;
    });
  }
  async deletePatient(id: number) {
    this.service
      .deletePatient(id)
      .then((response: any) => {
        console.log(response);
        this.utils.refresh();
      })
      .catch((err) => {
        console.error(err);
      });
  }
}
