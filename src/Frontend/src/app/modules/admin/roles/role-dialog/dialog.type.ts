import type { IRole } from '../role/role.interface';

export interface DialogType {
  formType: FormType;
  role?: IRole;
}

export enum FormType {
  CREATE = 'create',
  EDIT = 'edit',
}
