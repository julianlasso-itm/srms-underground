export interface ISkill {
    skillId: string;
    name: string;
    disabled: boolean;
}

export interface ISubSkill {
    skillId: string;
    name: string;
    subSkillId: string;
}

export interface ISkills {
    skills: ISkill[];
    total: number;
}

export interface ISubSkills {
    subSkills: ISubSkill[];
    total: number;
}
