import type { ICity } from '../city/city.interface';

export interface DialogType {
  formType: FormType;
  city?: ICity;
}

export enum FormType {
  CREATE = 'create',
  EDIT = 'edit',
}
