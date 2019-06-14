export interface EnrichmentResult
{
    errorMessage:string | null;
    status:EnrichmentResultStatus;
    enrichment:Enrichment;
}

export enum EnrichmentResultStatus
{
    NotFound,
    Found,
    Error,
    NotLoaded,
}

export class EnrichmentResultFactory
{
    static CreateEmpty() : EnrichmentResult
    {
        return { errorMessage: null, status:EnrichmentResultStatus.NotLoaded, enrichment:null };
    }
}

export interface Enrichment
{
    name:string;
    location:string;
    logo:string;
    page:string;
    info:string;
    isCompany:boolean;
}