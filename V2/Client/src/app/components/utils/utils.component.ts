import { Component } from '@angular/core';

@Component({
  selector: 'app-utils',
  standalone: true,
  imports: [],
  templateUrl: './utils.component.html',
  styleUrl: './utils.component.scss',
})
export class UtilsComponent {
  constructor() {}
  refresh(): void {
    window.location.reload();
  }
}
