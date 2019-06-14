import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { ApiService } from 'src/app/api.service';
import { Observable } from 'rxjs';
import { AuthUser } from './auth.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthService {

    constructor(@Inject(DOCUMENT) private document: Document, private apiService:ApiService) {

    }

    isUserAuthenticated() : Observable<AuthUser> {

        return this.apiService.geta("/IsUserAuthenticated");
    }

    login() {
        this.document.location.href = `${environment.account_api}/SignInWithGoogle`;
    }

    logout() {
        this.document.location.href = `${environment.account_api}/Logout`;
    }
}