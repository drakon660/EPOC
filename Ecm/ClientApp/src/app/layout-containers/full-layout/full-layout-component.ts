import { Component, OnInit, Type } from '@angular/core';
import { AuthService } from '../login-layout/auth.service';
import { map } from 'rxjs/operators';
import { Enrichment, EnrichmentResult, EnrichmentResultFactory, EnrichmentResultStatus } from './enrichment.model';
import { SearchService } from './search.service';
import { Observable, of, Observer } from 'rxjs';
import { Router } from '@angular/router';
import { Result, ResultFactory } from './result.model';

@Component({
    templateUrl: 'full-layout.component.html'
})

export class FullLayoutComponent implements OnInit {
    constructor(private authService: AuthService, private searchService: SearchService, private router: Router) { }
    searchText: string = '';
    isbuttonDisabled: boolean;
    loading: boolean;

    enrichmentResultStatus = EnrichmentResultStatus;
    result: Result = ResultFactory.CreateEmpty(EnrichmentResultFactory.CreateEmpty());

    userName: string = "";

    ngOnInit() {
        this.userName = localStorage.getItem("user");
    }

    search(searchText: string) {
        if (!searchText) {
            alert('Please fill entity name country input');
            return;
        }

        this.result = ResultFactory.CreateEmpty(EnrichmentResultFactory.CreateEmpty());
        this.loader(true);

        this.searchService.search(searchText).subscribe(result => {
            //this.result = result;
            //console.log(this.result);
            if (result.isSuccess)
                this.result = result;
            else if (result.isFailure)
                alert('Please fill entity name country input');
            //console.log(result);
        }
            , (error: string) => {
                if (error.indexOf('Account/Login') > -1)
                    this.router.navigate(['/login/sessionexpired']);
                else
                    this.router.navigate(['/login']);
            }, () => {
                this.loader(false);
            });
    }

    loader(show: boolean) {
        this.isbuttonDisabled = show;
        this.loading = show;
    }

    logout() {
        localStorage.removeItem("user");
        this.authService.logout();
    }
}