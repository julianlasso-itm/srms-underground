import type { ISkill } from '../skill/skill.interface';

export interface DialogType {
    formType: FormType;
    skill?: ISkill;
}

export enum FormType {
    CREATE = 'create',
    EDIT = 'edit',
}
