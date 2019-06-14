import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Observable, of } from 'rxjs';
import { Result } from './result.model';

@Injectable()
export class SearchService {

    constructor(private apiService:ApiService) { }

    search(searchText:string) : Observable<Result>
    {
        return this.apiService.get(`/search/${searchText}`);
    }
}