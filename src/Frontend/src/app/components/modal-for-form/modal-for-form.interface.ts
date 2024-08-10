import { WritableSignal } from '@angular/core';
import { FormControl } from '@angular/forms';

export interface IModalForForm {
  title: string;
  form: WritableSignal<Array<FormField>>;
  submit: Function;
  action: string;
  data: object;
}

export interface FormField {
  field: string;
  label?: string;
  type: TypeInput;
  placeholder?: string;
  maxLength?: number;
  icon?: string;
  formControl?: WritableSignal<FormControl>;
  loadOptions?: (...args: any) => Array<object>;
  selectionChange?: (...args: any) => void;
  options?: Array<any>;
  defaultValue?: any;
}

export enum TypeInput {
  HIDDEN = 'hidden',
  TEXT = 'text',
  EMAIL = 'email',
  TEL = 'tel',
  SELECT = 'select',
  SLIDE_TOGGLE = 'slide-toggle',
  CHECKBOX = 'checkbox',
}
