import type { IAssesment } from '../assesment/assesment.interface';

export interface DialogType {
    formType: FormType;
    assesment?: IAssesment;
}

export enum FormType {
    CREATE = 'create',
    EDIT = 'edit',
}
