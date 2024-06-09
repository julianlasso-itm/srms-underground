import { ISkill } from "../../skills/skill/skill.interface";

export interface IRole {
    roleId: string;
    name: string;
    description?: string;
    disabled: boolean;
    skills: ISkill[];
}

export interface IRoles {
    roles: IRole[];
    total: number;
}
