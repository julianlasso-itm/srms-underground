import { CommonModule } from '@angular/common';
import {
    Component,
    EventEmitter,
    Input,
    OnInit,
    Output,
    Signal,
    computed,
    signal,
} from '@angular/core';
import {
    FormControl,
    FormGroup,
    ReactiveFormsModule,
    Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { ISkill, ISubSkill } from '../skill/skill.interface';

const URL_SKILL = `${Constant.URL_BASE}${Constant.URL_SKILL_DETAIL}`;

@Component({
    selector: 'srms-skill-detail-form',
    standalone: true,
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        ReactiveFormsModule,
        SharedModule,
    ],
    templateUrl: './skill-detail-form.component.html',
    styleUrl: './skill-detail-form.component.scss',
})
export class SkillDetailFormComponent implements OnInit {
    @Input() skill: Signal<ISubSkill | null> = signal(null);
    @Output('frmSkill') form: EventEmitter<Signal<FormGroup>>;
    public frmSkill: Signal<FormGroup>;
    private regexp =
        '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';

    constructor(
        private snackBar: MatSnackBar,
        public httpService: HttpService,
        public reloadDataService: ReloadDataService
    ) {
        this.frmSkill = signal(
            new FormGroup({
                name: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(50),
                ]),
            })
        );
        this.form = new EventEmitter<Signal<FormGroup>>();
    }

    ngOnInit(): void {
        if (this.skill()?.subSkillId !== undefined) {
            this.frmSkill().setControl(
                'subSkillId',
                new FormControl(this.skill()?.subSkillId, [
                    Validators.required,
                    Validators.pattern(this.regexp),
                ])
            );
            this.frmSkill().get('name')?.setValue(this.skill()?.name);
            this.frmSkill().setControl(
                'disabled',
                new FormControl<boolean>(!this.skill()?.disabled || false)
            );
        }
        this.frmSkill().setControl(
            'skillId',
            new FormControl(this.skill()?.skillId, [
                Validators.pattern(this.regexp),
            ])
        );
        this.form.emit(computed(() => this.frmSkill()));
    }

    onSubmit(): void {
        if (this.frmSkill().valid) {
            if (this.skill()?.subSkillId === undefined) {
                this.createSkill();
            } else {
                this.updateSkill();
            }
        }
    }

    private createSkill(): void {
        const body = this.frmSkill().value;
        console.log(body);
        this.httpService.post(URL_SKILL, body).subscribe({
            next: (response) => {
                console.log(response);
                this.reloadDataService.reload();
            },
            error: (error) => {
                console.error(error);
                this.handleException(error);
            },
            complete: () => {
                console.log('complete');
            },
        });
    }

    private updateSkill(): void {
        const body = this.frmSkill().value;
        body.disable = !body.disabled;
        delete body.disabled;

        const url = `${URL_SKILL}/${this.skill()?.subSkillId}`;
        delete body.subSkillId;

        this.httpService.put(url, body).subscribe({
            next: (response) => {
                console.log(response);
                this.reloadDataService.reload();
            },
            error: (error) => {
                console.error(error);
                this.handleException(error);
            },
            complete: () => {
                console.log('complete');
            },
        });
    }

    private handleException(error: any): void {
        if (error.status === 409 && error.error.Errors.startsWith('23505')) {
            this.snackBar.open(
                'La habilidad que intentas crear ya existe',
                'Cerrar',
                {
                    duration: 5000,
                }
            );
        } else {
            this.snackBar.open(
                'Hay un error no controlado al crear una Habilidad',
                'Cerrar',
                {
                    duration: 5000,
                }
            );
        }
    }
}
