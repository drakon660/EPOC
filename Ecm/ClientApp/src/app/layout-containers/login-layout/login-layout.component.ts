import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { ActivatedRoute, Params } from '@angular/router';
import { AuthResultType, AuthResult } from './auth.model';

@Component({
    templateUrl: 'login-layout.component.html'
})

export class LoginLayoutComponent implements OnInit {
    authResultType = AuthResultType;
    authResult: AuthResult;

    constructor(private authService: AuthService, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.forEach((params: Params) => {
            const message = params['message'];
            if (message) {
                if (message == "errorprovider") {
                    this.authResult = new AuthResult('Google Outh Error', AuthResultType.Error);
                }
                else if (message == "notauthorized") {
                    this.authResult = new AuthResult('You are not authorized', AuthResultType.NotAuthorized);
                }
                else if (message == 'error') {
                    this.authResult = new AuthResult('Some Error', AuthResultType.Error);
                }
                else if (message == 'sessionexpired') {
                    this.authResult = new AuthResult('', AuthResultType.SessionExpired);
                }
                else {
                    this.authResult = new AuthResult('Fatal Error', AuthResultType.Error);
                }
            }
            else
            {
                this.authResult = new AuthResult('', AuthResultType.Empty);
            }
        });
    }

    login() {
        this.authService.login();
    }
}