import { IProvince } from "../../../profiles/provinces/province/province.interface";

export interface IAssesment {
    assesmentId: string;
    name: string;
    provinceId: string; // TODO: IProvince asignar el tipo correcto, por qué?
    province: IProvince;
    disabled: boolean;
}

export interface IAssesments {
    assessments: IAssesment[];
    total: number;
}
