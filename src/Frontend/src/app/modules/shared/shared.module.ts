import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from './services/http.service';
import { AuthService } from './services/auth.service';
import { StoreService } from './services/store.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  // providers: [HttpService, StoreService, AuthService],
  exports: [],
})
export class SharedModule {}
