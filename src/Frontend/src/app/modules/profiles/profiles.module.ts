import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { profilesRoutes } from './profiles.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(profilesRoutes)],
})
export class ProfilesModule {}
