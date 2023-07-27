export interface IAuthor{
    idAuthor: number;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
}
export interface IComment{
    idComment: number;
    title: string;
    description: string;
    dateTimeCreated: Date;
    dateTimeUpdated: Date;
    author: IAuthor;
}
