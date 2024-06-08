import type { ISquad } from '../squad/squad.interface';

export interface DialogType {
    formType: FormType;
    squad?: ISquad;
}

export enum FormType {
    CREATE = 'create',
    EDIT = 'edit',
}
