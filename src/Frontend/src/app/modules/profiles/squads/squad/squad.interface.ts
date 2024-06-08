export interface ISquad {
    squadId: string;
    name: string;
    disabled: boolean;
}

export interface ISquads {
    squads: ISquad[];
    total: number;
}
