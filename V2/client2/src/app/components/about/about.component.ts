import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';
import { LoadingScreenComponent } from '../../reusable-components/loading-screen/loading-screen.component';
import { About } from '../../interfaces/about';
import { AboutService } from '../../services/about/about.service';
import { NgIf } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TIME_LOADING } from '../../constants';
@Component({
  selector: 'app-about',
  standalone: true,
  imports: [LogoComponent, LoadingScreenComponent, NgIf, RouterModule],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
})
export class AboutComponent {
  isLoading!: boolean;
  content!: string;
  constructor(private aboutService: AboutService) {
    this.getContent().then((response: any) => {
      this.content = response[0].content;
      setTimeout(() => {
        this.isLoading = false;
      }, TIME_LOADING);
    });
  }
  async getContent() {
    try {
      this.isLoading = true;
      return await this.aboutService.fetchData();
    } catch (error) {
      throw new Error('Failed to fetch data:' + error);
    }
  }
}
