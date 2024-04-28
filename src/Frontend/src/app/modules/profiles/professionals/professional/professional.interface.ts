export interface IProfessional {
  professionalId: string;
  name: string;
  email?: string;
  disabled: boolean;
}

export interface IProfessionals {
  professionals: IProfessional[];
  total: number;
}
