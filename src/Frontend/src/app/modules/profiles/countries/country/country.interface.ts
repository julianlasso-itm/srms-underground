export interface ICountry {
  countryId: string;
  name: string;
  disabled: boolean;
}

export interface ICountries {
  countries: ICountry[];
  total: number;
}
