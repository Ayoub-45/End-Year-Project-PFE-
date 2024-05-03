import { Component, Input } from '@angular/core';
import { Pathologie } from '../../interfaces/pathologie';
import { PathologieService } from 'src/app/services/pathologie/pathologie.service';
@Component({
  selector: 'app-pathologie',
  standalone: true,
  imports: [],
  templateUrl: './pathologie.component.html',
  styleUrl: './pathologie.component.scss',
})
export class PathologieComponent {
  @Input() id!: number;
  pathologie!: Pathologie;
  constructor(private pathologieService: PathologieService) {
    this.pathologieService
      .fetchData()
      .then((response) => {
        this.pathologie = response.find((p: Pathologie) => p.id === this.id);
      })
      .catch((err) => console.log(err));
    console.log(this.id);
  }
}
