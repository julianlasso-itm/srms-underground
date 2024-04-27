export interface ISkill {
  skillId: string;
  name: string;
  disabled: boolean;
}

export interface ISkills {
  skills: ISkill[];
  total: number;
}
