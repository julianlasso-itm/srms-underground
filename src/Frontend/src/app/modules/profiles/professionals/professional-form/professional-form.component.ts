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
import { IProfessional } from '../professional/professional.interface';

const URL_PROFESSIONAL = `${Constant.URL_BASE}${Constant.URL_PROFESSIONAL}`;

@Component({
    selector: 'srms-professional-form',
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
    templateUrl: './professional-form.component.html',
    styleUrl: './professional-form.component.scss',
})
export class ProfessionalFormComponent implements OnInit {
    @Input() professional: Signal<IProfessional | null> = signal(null);
    @Output('frmProfessional') form: EventEmitter<Signal<FormGroup>>;
    public frmProfessional: Signal<FormGroup>;
    private regexp =
        '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';

    constructor(
        private snackBar: MatSnackBar,
        public httpService: HttpService,
        public reloadDataService: ReloadDataService
    ) {
        this.frmProfessional = signal(
            new FormGroup({
                name: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(50),
                ]),
                email: new FormControl('', [
                    Validators.maxLength(50),
                    Validators.required,
                    Validators.pattern(
                        '^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'
                    ),
                ]),
            })
        );
        this.form = new EventEmitter<Signal<FormGroup>>();
    }

    ngOnInit(): void {
        if (this.professional()?.professionalId !== undefined) {
            this.frmProfessional().setControl(
                'professionalId',
                new FormControl(this.professional()?.professionalId, [
                    Validators.required,
                    Validators.pattern(this.regexp),
                ])
            );
            this.frmProfessional()
                .get('name')
                ?.setValue(this.professional()?.name);
            this.frmProfessional()
                .get('email')
                ?.setValue(this.professional()?.email);
            this.frmProfessional().setControl(
                'disabled',
                new FormControl<boolean>(
                    !this.professional()?.disabled || false
                )
            );
        }
        this.form.emit(computed(() => this.frmProfessional()));
    }

    onSubmit(): void {
        if (this.frmProfessional().valid) {
            if (this.professional()?.professionalId === undefined) {
                this.createProfessional();
            } else {
                this.updateProfessional();
            }
        }
    }

    private createProfessional(): void {
        const body = this.frmProfessional().value;
        if (body.email === '') {
            delete body.email;
        }
        this.httpService.post(URL_PROFESSIONAL, body).subscribe({
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

    private updateProfessional(): void {
        const body = this.frmProfessional().value;
        if (body.email === '') {
            body.email = null;
        }
        body.disable = !body.disabled;
        delete body.disabled;

        const url = `${URL_PROFESSIONAL}/${
            this.professional()?.professionalId
        }`;
        delete body.professionalId;

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
                'El correo electronico asociado ya está registrado',
                'Cerrar',
                {
                    duration: 5000,
                }
            );
        } else {
            this.snackBar.open(
                'Hay un error no controlado al crear un Profesional, por favor contacte al administrador del sistema.',
                'Cerrar',
                {
                    duration: 5000,
                }
            );
        }
    }
}
