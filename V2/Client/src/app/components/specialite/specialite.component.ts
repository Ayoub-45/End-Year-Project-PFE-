import { Component, Input } from '@angular/core';
import { Specialite } from 'src/app/interfaces/specialite';
import { SpecialiteService } from 'src/app/services/specialite/specialite.service';

@Component({
  selector: 'app-specialite',
  standalone: true,
  imports: [],
  templateUrl: './specialite.component.html',
  styleUrl: './specialite.component.scss',
})
export class SpecialiteComponent {
  specialite!: Specialite;
  @Input() id!: number;
  constructor(private specialteService: SpecialiteService) {
    this.getSpecialtes().then((response: Specialite[]) => {
      this.specialite = response.filter((speci) => speci.id !== this.id)[0];
    });
  }
  async getSpecialtes() {
    const data = await this.specialteService.fetchData();
    return data;
  }
}
