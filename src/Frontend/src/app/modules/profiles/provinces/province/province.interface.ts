import type { ICountry } from '../../countries/country/country.interface';

export interface IProvince {
  provinceId: string;
  name: string;
  countryId: ICountry;
  disabled: boolean;
}

export interface IProvinces {
  provinces: IProvince[];
  total: number;
}
