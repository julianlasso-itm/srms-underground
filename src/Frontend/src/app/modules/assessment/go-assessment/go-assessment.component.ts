import { HttpParams } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatStepperModule } from '@angular/material/stepper';
import { ActivatedRoute } from '@angular/router';
import { ChartConfiguration } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { Constant } from '../../shared/constants/constants';
import { HttpService } from '../../shared/services/http.service';
import { Assessments, SkillData, SubSkillData } from './interfaces';

const ranking = {
  sinDefinir: {
    name: 'Sin definir',
    value: 0,
  },
  principiante: {
    name: 'Principiante',
    value: 0.5,
  },
  juniorBasico: {
    name: 'Junior Básico',
    value: 1.0,
  },
  juniorIntermedio: {
    name: 'Junior Intermedio',
    value: 1.5,
  },
  juniorAvanzado: {
    name: 'Junior Avanzado',
    value: 2.0,
  },
  middleBasico: {
    name: 'Middle Básico',
    value: 2.5,
  },
  middleIntermedio: {
    name: 'Middle Intermedio',
    value: 3.0,
  },
  middleAvanzado: {
    name: 'Middle Avanzado',
    value: 3.5,
  },
  seniorBasico: {
    name: 'Senior Básico',
    value: 4.0,
  },
  seniorIntermedio: {
    name: 'Senior Intermedio',
    value: 4.5,
  },
  seniorAvanzado: {
    name: 'Senior Avanzado',
    value: 5.0,
  },
};

const URL_GET_ASSESSMENTS = `${Constant.URL_BASE}${Constant.URL_GET_ASSESSMENTS}`;

@Component({
  selector: 'srms-go-assessment',
  standalone: true,
  imports: [
    MatStepperModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    BaseChartDirective,
    ReactiveFormsModule,
    MatProgressBarModule,
  ],
  templateUrl: './go-assessment.component.html',
  styleUrl: './go-assessment.component.scss',
})
export class GoAssessmentComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart!: BaseChartDirective;
  public generalRanking: string = 'No definido';

  public radarChartOptions: ChartConfiguration<'radar'>['options'] = {
    responsive: false,
    plugins: {
      tooltip: {
        callbacks: {
          label: (context) => {
            return this.calculateRanking(Number(context.formattedValue));
          },
        },
      },
    },
    scales: {
      r: {
        beginAtZero: true,
        min: 0,
        max: 5,
        ticks: {
          display: false,
        },
      },
    },
  };
  public radarChartLabels: string[] = [];

  public radarChartDatasets: ChartConfiguration<'radar'>['data']['datasets'] = [
    {
      data: [],
      label: 'Evaluado',
      backgroundColor: 'rgba(0, 125, 255, 0.8)',
      borderColor: 'rgba(0, 125, 255, 1)',
    },
    {
      data: [],
      label: 'Principiante',
      backgroundColor: 'rgba(75, 75, 75, 0.1)',
      borderColor: 'rgba(75, 75, 75, 0.5)',
    },
    {
      data: [],
      label: 'Junior',
      backgroundColor: 'rgba(255, 45, 45, 0.1)',
      borderColor: 'rgba(255, 45, 45, 0.5)',
    },
    {
      data: [],
      label: 'Middle',
      backgroundColor: 'rgba(255, 206, 86, 0.1)',
      borderColor: 'rgba(255, 206, 86, 0.5)',
    },
    {
      data: [],
      label: 'Senior',
      backgroundColor: 'rgba(75, 192, 192, 0.1)',
      borderColor: 'rgba(75, 192, 192, 0.5)',
    },
  ];

  public frmGoAssessment: FormGroup;

  public radarChartType: ChartConfiguration<'radar'>['type'] = 'radar';

  public items: SkillData[] = [];

  public nameProfessional: string = 'Nombre del profesional';
  public roleProfessional: string = 'Rol del profesional';
  public assessmentId: string;

  constructor(
    activatedRoute: ActivatedRoute,
    private httpService: HttpService
  ) {
    this.assessmentId = activatedRoute.snapshot.params['id'];
    this.frmGoAssessment = new FormGroup({});
  }

  ngOnInit(): void {
    const params = new HttpParams()
      .append('Page', 1)
      .append('Limit', 9999999)
      .append('Filter', this.assessmentId)
      .append('FilterBy', 'AssessmentId');
    this.httpService.get<Assessments>(URL_GET_ASSESSMENTS, params).subscribe({
      next: (response) => {
        this.nameProfessional = response.assessments[0].professional.name;
        this.roleProfessional = response.assessments[0].role.name;
        this.items = this.createStructure(response);
        this.InitializeForm(this.items);
        this.InitializeGraph();
      },
      error: (error) => {
        console.error(error);
      },
    });
    this.InitializeForm(this.items);
    this.InitializeGraph();
  }

  onSubskillChange(value: string, skill: string, subskill: string) {
    const item = this.items.find((item) => item.id === skill);
    if (item) {
      const sub = item.skills.find((sub) => sub.id === subskill);
      if (sub) {
        sub.value = Number(value);
      }
    }

    const skillItem: SkillData | undefined = this.items.find(
      (item) => item.id === skill
    );
    if (skillItem && skillItem.skills.length > 0) {
      const totalValue = skillItem.skills.reduce(
        (acc, sub) => acc + sub.value,
        0
      );
      skillItem.value = totalValue / skillItem.skills.length; // Calcula el promedio de las subskills
    }

    this.generalRanking = this.calculateRanking(
      this.items.reduce((acc, item) => acc + item.value, 0) / this.items.length // Calcula el promedio general
    );

    // actualiza el valor de la gráfica
    this.radarChartDatasets[0].data = this.items.map((item) => item.value);
    this.chart.update();
  }

  private InitializeForm(data: SkillData[]) {
    data.forEach((skill) => {
      skill.skills.forEach((subSkill) => {
        this.frmGoAssessment.addControl(
          `subskill-${subSkill.id}`,
          new FormControl(subSkill.value, Validators.required)
        );
        this.frmGoAssessment.addControl(
          `subskill-${subSkill.id}-observations`,
          new FormControl(subSkill.observations)
        );
      });
    });
  }

  private InitializeGraph() {
    this.radarChartLabels = this.items.map((item) => item.name);
    this.radarChartDatasets[0].data = this.items.map((item) => item.value);
    this.radarChartDatasets[1].data = this.radarChartLabels.map(
      () => ranking.principiante.value
    );
    this.radarChartDatasets[2].data = this.radarChartLabels.map(
      () => ranking.juniorAvanzado.value
    );
    this.radarChartDatasets[3].data = this.radarChartLabels.map(
      () => ranking.middleAvanzado.value
    );
    this.radarChartDatasets[4].data = this.radarChartLabels.map(
      () => ranking.seniorAvanzado.value
    );
  }

  public calculateRanking(value: number): string {
    const rankings = [
      { value: ranking.sinDefinir.value, name: ranking.sinDefinir.name },
      { value: ranking.principiante.value, name: ranking.principiante.name },
      { value: ranking.juniorBasico.value, name: ranking.juniorBasico.name },
      {
        value: ranking.juniorIntermedio.value,
        name: ranking.juniorIntermedio.name,
      },
      {
        value: ranking.juniorAvanzado.value,
        name: ranking.juniorAvanzado.name,
      },
      { value: ranking.middleBasico.value, name: ranking.middleBasico.name },
      {
        value: ranking.middleIntermedio.value,
        name: ranking.middleIntermedio.name,
      },
      {
        value: ranking.middleAvanzado.value,
        name: ranking.middleAvanzado.name,
      },
      { value: ranking.seniorBasico.value, name: ranking.seniorBasico.name },
      {
        value: ranking.seniorIntermedio.value,
        name: ranking.seniorIntermedio.name,
      },
      {
        value: ranking.seniorAvanzado.value,
        name: ranking.seniorAvanzado.name,
      },
    ];

    const rank = rankings.find((rank) =>
      value === 0 ? rank.value === value : value <= rank.value
    );
    return rank ? rank.name : ranking.seniorAvanzado.name;
  }

  private createStructure(assessments: Assessments): SkillData[] {
    const items: SkillData[] = [];

    assessments.assessments.forEach((assessment, assessmentIndex) => {
      assessment.skills.forEach((skill, skillIndex) => {
        const subSkills: SubSkillData[] = skill.subSkills.map(
          (subSkill, subSkillIndex) => {
            const result =
              subSkill.results.length > 0 ? subSkill.results[0] : null;
            return {
              id: subSkill.subSkillId,
              position: subSkillIndex + 1,
              name: subSkill.name,
              description: '',
              value: result ? result.result : 0,
              observations: result ? result.comment ?? '' : '',
            };
          }
        );

        items.push({
          id: skill.skillId,
          position: skillIndex + 1,
          name: skill.name,
          description: skill.name,
          value: subSkills.length > 0 ? subSkills[0].value : 0,
          skills: subSkills,
        });
      });
    });

    return items;
  }
}
