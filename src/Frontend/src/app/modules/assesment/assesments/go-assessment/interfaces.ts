export interface Assessments {
  assessments: Assessment[];
  total: number;
}

export interface Assessment {
  assessmentId: string;
  professionalId: string;
  roleId: string;
  squadId: string;
  professional: Professional;
  role: Role;
  squad: Squad;
  skills: Skill[];
}

export interface Professional {
  professionalId: string;
  name: string;
  email: string;
  disabled: boolean;
}

export interface Role {
  roleId: string;
  name: string;
  description: null;
  disabled: boolean;
}

export interface Skill {
  skillId: string;
  name: string;
  disabled: boolean;
  subSkills: SubSkill[];
}

export interface SubSkill {
  subSkillId: string;
  skillId: string;
  name: string;
  disabled: boolean;
  results: Result[];
}

export interface Result {
  resultId: string;
  assessmentId: string;
  subSkillId: string;
  result: number;
  comment: null;
  dateTime: Date;
}

export interface Squad {
  squadId: string;
  name: string;
  disabled: boolean;
}

export interface SkillData {
  id: string;
  position: number;
  name: string;
  description: string;
  value: number;
  skills: SubSkillData[];
}

export interface SubSkillData {
  id: string;
  position: number;
  name: string;
  description: string;
  value: number;
  observations: string;
}
