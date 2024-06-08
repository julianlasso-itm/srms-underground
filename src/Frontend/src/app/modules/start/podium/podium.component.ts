import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { HttpService } from '../../shared/services/http.service';
import { Constant } from '../../shared/constants/constants';
import { IPodium } from './podium.interface';

@Component({
  selector: 'srms-podium',
  standalone: true,
  imports: [
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatToolbarModule,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './podium.component.html',
  styleUrl: './podium.component.scss',
})
export class PodiumComponent {
  podiumUsers: any[];

  constructor(private httpService: HttpService) {
    this.podiumUsers = [];
    this.obtenerPodium();
  }

  private obtenerPodium(): void {
    console.log('Obteniendo podium');
    const URL_GET_PODIUM = `${Constant.URL_BASE}${Constant.URL_GET_PODIUM}`;
    this.httpService.get<IPodium>(URL_GET_PODIUM).subscribe({
      next: (data) => {
        console.log(data);
        if (data.podium !== null) {
          this.podiumUsers = data.podium;
        } else {
            this.podiumUsers = []
        }
      },
      error: (error) => {
        console.error(error.message);
        //TODO: Remove this mock data
        this.podiumUsers = [
            { name: 'User 1', mail:"mail@example.com", imageUrl: 'https://orderszulu2024.blob.core.windows.net/users/SRMS-694f6489-39c6-4547-876f-ff89f96eb653.webp' },
            { name: 'User 2', mail:"mail@example.com", imageUrl: 'https://orderszulu2024.blob.core.windows.net/users/SRMS-694f6489-39c6-4547-876f-ff89f96eb653.webp' },
            { name: 'User 3', mail:"mail@example.com", imageUrl: 'https://orderszulu2024.blob.core.windows.net/users/SRMS-694f6489-39c6-4547-876f-ff89f96eb653.webp' }
          ];
      },
    });
  }
}
