export enum AuthResultType
{
    Error,
    ErrorProvider,
    NotAuthorized,
    Empty,
    SessionExpired
}

export class AuthResult
{
    message:string | null;
    type:AuthResultType;
    constructor(message:string, type:AuthResultType)
    {
        this.message = message;
        this.type = type;
    }
}

export class AuthUser
{
    name:string;
    isAuthenticated : boolean;
}