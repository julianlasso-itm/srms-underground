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
import { ISquad } from '../squad/squad.interface';

const URL_SQUAD = `${Constant.URL_BASE}${Constant.URL_SQUAD}`;

@Component({
    selector: 'srms-squad-form',
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
    templateUrl: './squad-form.component.html',
    styleUrl: './squad-form.component.scss',
})
export class SquadFormComponent implements OnInit {
    @Input() squad: Signal<ISquad | null> = signal(null);
    @Output('frmSquad') form: EventEmitter<Signal<FormGroup>>;
    public frmSquad: Signal<FormGroup>;
    private regexp =
        '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';

    constructor(
        private snackBar: MatSnackBar,
        public httpService: HttpService,
        public reloadDataService: ReloadDataService
    ) {
        this.frmSquad = signal(
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
        if (this.squad()?.squadId !== undefined) {
            this.frmSquad().setControl(
                'squadId',
                new FormControl(this.squad()?.squadId, [
                    Validators.required,
                    Validators.pattern(this.regexp),
                ])
            );
            this.frmSquad().get('name')?.setValue(this.squad()?.name);
            this.frmSquad().setControl(
                'disabled',
                new FormControl<boolean>(!this.squad()?.disabled || false)
            );
        }
        this.form.emit(computed(() => this.frmSquad()));
    }

    onSubmit(): void {
        if (this.frmSquad().valid) {
            if (this.squad()?.squadId === undefined) {
                this.createSquad();
            } else {
                this.updateSquad();
            }
        }
    }

    private createSquad(): void {
        const body = this.frmSquad().value;
        this.httpService.post(URL_SQUAD, body).subscribe({
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

    private updateSquad(): void {
        const body = this.frmSquad().value;
        body.disable = !body.disabled;
        delete body.disabled;

        const url = `${URL_SQUAD}/${this.squad()?.squadId}`;
        delete body.squadId;

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
