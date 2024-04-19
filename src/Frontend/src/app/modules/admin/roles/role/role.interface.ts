export interface IRole {
  roleId: string;
  name: string;
  description?: string;
  disabled: boolean;
}

export interface IRoles {
  roles: IRole[];
  total: number;
}
