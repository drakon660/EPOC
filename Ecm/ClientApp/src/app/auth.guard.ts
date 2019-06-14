import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './layout-containers/login-layout/auth.service';
import { map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthUser } from './layout-containers/login-layout/auth.model';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {
    constructor(private authService:AuthService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) : Observable<boolean>  {
        
      return this.authService.isUserAuthenticated().pipe(map((user:AuthUser)=>{
        if(user)
        {
          if(user.isAuthenticated) 
          {
              localStorage.setItem("user", user.name);
              return true;
          }
          else
          {
              this.router.navigate(['/login']);
              return false;
          }
        }
        this.router.navigate(['/login']);
        return false;
      }));
    }
}