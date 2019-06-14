import { NgModule } from '@angular/core';
import { LoginLayoutComponent } from "./login-layout/login-layout.component";
import { RouterModule } from '@angular/router';
import { FullLayoutComponent } from './full-layout/full-layout-component';
import { AuthService } from './login-layout/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SearchService } from './full-layout/search.service';
import { EntityPipe } from '../entity.pipe';
import { NgxLoadingModule } from 'ngx-loading';

const COMPONENTS = [EntityPipe, LoginLayoutComponent, FullLayoutComponent];
const SERVICES = [AuthService, SearchService]

@NgModule({
  declarations: [...COMPONENTS],
  imports: [RouterModule, CommonModule, FormsModule, NgxLoadingModule.forRoot({})],
  providers:[...SERVICES],
  exports: [...COMPONENTS]
})
export class LayoutContainersModule {}
