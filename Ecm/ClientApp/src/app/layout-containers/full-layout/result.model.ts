import { EnrichmentResult } from "./enrichment.model";

export interface Result
{
    value:EnrichmentResult | null;
    isSuccess:boolean;
    isFailure:boolean;
    error:string;
}

export class ResultFactory
{
    static CreateEmpty(result:EnrichmentResult) : Result
    {
        return { error : '', isSuccess: true, isFailure : false, value: result  };
    }
}