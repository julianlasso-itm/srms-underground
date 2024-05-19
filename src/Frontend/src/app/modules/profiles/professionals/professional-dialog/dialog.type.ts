import type { IProfessional } from '../professional/professional.interface';

export interface DialogType {
    formType: FormType;
    professional?: IProfessional;
}

export enum FormType {
    CREATE = 'create',
    EDIT = 'edit',
}
