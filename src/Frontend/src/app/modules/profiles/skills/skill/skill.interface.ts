import { IRole } from "../../roles/role/role.interface";

export interface ISkill {
    skillId: string;
    name: string;
    role: IRole;
    disabled: boolean;
}

export interface ISubSkill {
    skillId: string;
    name: string;
    subSkillId: string;
    disabled: boolean;
}

export interface ISkills {
    skills: ISkill[];
    total: number;
}

export interface ISubSkills {
    subSkills: ISubSkill[];
    total: number;
}
