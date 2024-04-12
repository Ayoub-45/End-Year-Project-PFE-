import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { HeaderComponent } from '../header/header.component';
import { ContentComponent } from '../content/content.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent, HeaderComponent, ContentComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  public copyRight = new Date().getFullYear();
}
