import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [LogoComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
})
export class AboutComponent {
  content =
    "Medical Clinics is your dedicated ally in the journey through thyroid conditions. Our platform provides comprehensive support and resources tailored specifically for individuals facing medical challenges related to thyroid health. From expert insights to community-driven assistance, we're committed to empowering you with the knowledge and tools needed to thrive despite your condition. Join us as we navigate this journey together towards optimal health and vitality";
}
