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
import { HttpParams } from '@angular/common/http';

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

    let params = new HttpParams()
      .append('Page', '1')
      .append('Limit', '3')
    console.log('Obteniendo podium');
    const URL_GET_PODIUM = `${Constant.URL_BASE}${Constant.URL_GET_PODIUM}`;
    this.httpService.get<IPodium>(URL_GET_PODIUM, params).subscribe({
      next: (data) => {
        if (data.podium !== null) {
          this.podiumUsers = data.podium;
        } else {
            this.podiumUsers = []
        }
      },
      error: (error) => {
        console.error(error.message);        
      },
    });
  }
}
