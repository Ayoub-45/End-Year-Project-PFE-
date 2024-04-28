import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';
import { animate, style, transition, trigger } from '@angular/animations';
import { LoadingScreenComponent } from '../../reusable-components/loading-screen/loading-screen.component';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [LogoComponent, LoadingScreenComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
  animations: [
    trigger('fadeInOut', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('500ms ease-out', style({ opacity: 1 })),
      ]),
      transition(':leave', [animate('500ms ease-in', style({ opacity: 0 }))]),
    ]),
  ],
})
export class AboutComponent {
  isloading = true;
  content = `Medical Clinics is your dedicated ally in the journey through thyroid
  conditions. Our platform provides comprehensive support and resources
  tailored specifically for individuals facing medical challenges related to
  thyroid health. From expert insights to community-driven assistance, we're
  committed to empowering you with the knowledge and tools needed to thrive
  despite your condition. towards optimal health and vitality.`;
}
