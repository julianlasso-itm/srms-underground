import type { ISkill, ISubSkill } from '../skill/skill.interface';

export interface DialogType {
    formType: FormType;
    skill?: ISubSkill;
}

export enum FormType {
    CREATE = 'create',
    EDIT = 'edit',
}
