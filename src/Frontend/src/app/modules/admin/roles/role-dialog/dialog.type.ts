export interface DialogType {
  formType: FormType;
  id?: string;
}

export enum FormType {
  CREATE = 'create',
  EDIT = 'edit',
}
