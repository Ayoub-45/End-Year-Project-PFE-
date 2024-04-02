import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeletePatientComponent } from './components/delete-patient/delete-patient.component';

export const routes: Routes = [
  // Other routes
  { path: '/:id', component: DeletePatientComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
