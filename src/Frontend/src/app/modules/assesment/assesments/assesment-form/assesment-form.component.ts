import { CommonModule } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, Signal, computed, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { IAssesment } from '../assesment/assesment.interface';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete'; 
import { Observable, map, startWith } from 'rxjs';
import { __values } from 'tslib';

const URL_ASSESMENT = `${Constant.URL_BASE}${Constant.URL_ASSESMENT}`;
const URL_GET_ROLES = `${Constant.URL_BASE}${Constant.URL_GET_ROLES}`;
const URL_GET_SQUADS = `${Constant.URL_BASE}${Constant.URL_GET_SQUADS}`;
const URL_GET_PROFESSIONALS = `${Constant.URL_BASE}${Constant.URL_GET_PROFESSIONALS}`;

@Component({
    selector: 'srms-assesment-form',
    standalone: true,
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        ReactiveFormsModule,
        SharedModule,
        MatAutocompleteModule,
    ],
    templateUrl: './assesment-form.component.html',
    styleUrl: './assesment-form.component.scss',
})
export class AssesmentFormComponent implements OnInit {
    @Input() assesment: Signal<IAssesment | null> = signal(null);
    @Output('frmAssesment') form: EventEmitter<Signal<FormGroup>>;
    public frmAssesment: Signal<FormGroup>;
    private regexp = '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';
    roles: any[] = [];  // Define proper interfaces if available
    squads: any[] = [];  // Define proper interfaces if available
    professionals: any[] = [];  // Define proper interfaces if available

    roleIdControl = new FormControl('', [Validators.required]);
    squadIdControl = new FormControl('', [Validators.required]);
    professionalIdControl = new FormControl('', [Validators.required]);


    constructor(
        private snackBar: MatSnackBar,
        public httpService: HttpService,
        public reloadDataService: ReloadDataService
    ) {

        this.frmAssesment = signal(
            new FormGroup({
                roleId: this.roleIdControl,
                squadId: this.squadIdControl,
                professionalId: this.professionalIdControl,
            })
        );
        this.form = new EventEmitter<Signal<FormGroup>>();
    }

    filteredRoles: Observable<any[]> | undefined;
    filteredSquads: Observable<any[]> | undefined;
    filteredProfessionals: Observable<any[]> | undefined;

    ngOnInit(): void {
        this.loadRoles();
        this.loadSquads();
        this.loadProfessionals();

        this.filteredRoles = this.roleIdControl.valueChanges.pipe(
            startWith(null),
            map(value => this._filter(value! || '', this.roles))
        );

        this.filteredSquads = this.squadIdControl.valueChanges.pipe(
            startWith(null),
            map(value => this._filter(value || '', this.squads))
        );

        this.filteredProfessionals = this.professionalIdControl.valueChanges.pipe(
            startWith(null),
            map(value => this._filter(value || '', this.professionals))
        );

        if (this.assesment()?.assesmentId !== undefined) {
            this.frmAssesment().setControl(
                'assesmentId',
                new FormControl(this.assesment()?.assesmentId, [
                    Validators.required,
                    Validators.pattern(this.regexp),
                ])
            );
            this.frmAssesment().get('squadId')?.setValue(this.assesment()?.assesmentId);
            this.frmAssesment().get('roleId')?.setValue(this.assesment()?.assesmentId);
            this.frmAssesment().get('professionalId')?.setValue(this.assesment()?.assesmentId);
            
            this.frmAssesment().setControl(
                'disabled',
                new FormControl<boolean>(!this.assesment()?.disabled || false)
            );
        }
        this.form.emit(computed(() => this.frmAssesment()));
    }

    private _filter(value: string | IAssesment, options: any[]): any[] {
        if (typeof(value) === 'string') {
            const filterValue = value.toLowerCase();
            return options.filter(option => option.name.toLowerCase().includes(filterValue));
        }
        return options.filter(option => option.name.toLowerCase().includes(value.name));
    }
    
    onRoleSelected(event: MatAutocompleteSelectedEvent): void {
        this.frmAssesment().get('roleId')?.setValue(event.option.value);
    }

    onSquadSelected(event: MatAutocompleteSelectedEvent): void {
        this.frmAssesment().get('squadId')?.setValue(event.option.value);
    }

    onProfessionalSelected(event: MatAutocompleteSelectedEvent): void {
        this.frmAssesment().get('professionalId')?.setValue(event.option.value);
    }
    
    displayOption(option: any): string {
        console.log(option);
        return option ? option.name : '';
    }

    onSubmit(): void {
        console.log(this.frmAssesment().value);
        console.log(this.frmAssesment().valid);
        if (this.frmAssesment().valid) {
            if (this.assesment()?.assesmentId === undefined) {
                this.createAssesment();
            } else {
                this.updateAssesment();
            }
        }
    }

    private createAssesment(): void {
        const body = this.mapBody(this.frmAssesment().value);
        
        this.httpService.post(URL_ASSESMENT, body).subscribe({
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

    private mapBody(body: any): any {
        return {
            roleId: body.roleId.roleId,
            squadId: body.squadId.squadId,
            professionalId: body.professionalId.professionalId,
        };
    }

    private updateAssesment(): void {
        const body = this.frmAssesment().value;
        const url = `${URL_ASSESMENT}/${this.assesment()?.assesmentId}`;
        delete body.assesmentId;

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

    private loadRoles(): void {
        let params = new HttpParams()
            .append('Page', 1)
            .append('Limit', 9999999);
        this.httpService.get(URL_GET_ROLES, params).subscribe({
            next: (response: any) => {
                this.roles = response.roles;
            },
            error: (error) => {
                console.error(error);
                this.handleException(error);
            },
        });
    }

    private loadSquads(): void {
        let params = new HttpParams()
            .append('Page', 1)
            .append('Limit', 9999999);
        this.httpService.get(URL_GET_SQUADS, params).subscribe({
            next: (response: any) => {
                this.squads = response.squads;
            },
            error: (error) => {
                console.error(error);
                this.handleException(error);
            },
        });
    }

    private loadProfessionals(): void {
        let params = new HttpParams()
            .append('Page', 1)
            .append('Limit', 9999999);
        this.httpService.get(URL_GET_PROFESSIONALS, params).subscribe({
            next: (response: any) => {
                this.professionals = response.professionals;
            },
            error: (error) => {
                console.error(error);
                this.handleException(error);
            },
        });
    }

    private handleException(error: any): void {
        const errorMessages = new Map([
            ['409_23505', 'El registro ya existe'],
            ['409_23503', 'No es posible eliminar un registro porque tiene otros registros asociados'],
        ]);

        const errorKey = `${error.status}_${error.error.Errors.substring(0, 5)}`;
        const message = errorMessages.get(errorKey) ?? error.error.Errors ?? 'Error desconocido';

        this.snackBar.open(message, 'Cerrar', { duration: 5000 });
    }
}
