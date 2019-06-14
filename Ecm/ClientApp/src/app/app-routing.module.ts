import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FullLayoutComponent } from './layout-containers/full-layout/full-layout-component';
import { LoginLayoutComponent } from './layout-containers/login-layout/login-layout.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [{
  path: '',
  component: FullLayoutComponent,
  canActivate: [AuthGuard]
}, {
  path: 'login/:message',
  component: LoginLayoutComponent
}, {
  path: 'login',
  component: LoginLayoutComponent
},
{
  path: 'Account/Login',
  redirectTo: ''
}]

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: false,
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }