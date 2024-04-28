import type { IProvince } from '../province/province.interface';

export interface DialogType {
  formType: FormType;
  province?: IProvince;
}

export enum FormType {
  CREATE = 'create',
  EDIT = 'edit',
}
