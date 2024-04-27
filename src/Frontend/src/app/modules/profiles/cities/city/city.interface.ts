import type { IProvince } from '../../provinces/province/province.interface';

export interface ICity {
  cityId: string;
  name: string;
  provinceId: string; // TODO: IProvince asignar el tipo correcto, por qué?
  province: IProvince;
  disabled: boolean;
}

export interface ICities {
  cities: ICity[];
  total: number;
}
