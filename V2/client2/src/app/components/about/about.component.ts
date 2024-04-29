import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';
import { LoadingScreenComponent } from '../../reusable-components/loading-screen/loading-screen.component';
import { About } from '../../interfaces/about';
import { AboutService } from '../../services/about/about.service';
@Component({
  selector: 'app-about',
  standalone: true,
  imports: [LogoComponent, LoadingScreenComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
})
export class AboutComponent {
  isloading = true;
  content: string = `Medical Clinics is your dedicated ally in the journey through thyroid
  conditions. Our platform provides comprehensive support and resources
  tailored specifically for individuals facing medical challenges related to
  thyroid health. From expert insights to community-driven assistance, we're
  committed to empowering you with the knowledge and tools needed to thrive
  despite your condition. towards optimal health and vitality.`;
  constructor(private aboutService: AboutService) {
    this.getContent().then((response) => {
      this.content = response.content;
    });
  }
  async getContent() {
    try {
      return await this.aboutService.fetchData();
    } catch (error) {
      throw new Error('Failed to fetch data:' + error);
    }
  }
}
