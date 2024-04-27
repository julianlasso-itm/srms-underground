import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { skillsRoutes } from './skills.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(skillsRoutes)],
})
export class SkillsModule {}
