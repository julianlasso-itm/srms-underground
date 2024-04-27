import type { ICountry } from '../country/country.interface';

export interface DialogType {
  formType: FormType;
  country?: ICountry;
}

export enum FormType {
  CREATE = 'create',
  EDIT = 'edit',
}
