export interface IUsers {
    name: string,
    position: string,
    imageUrl: string
}

export interface IPodium {
    podium: IUsers[];
}