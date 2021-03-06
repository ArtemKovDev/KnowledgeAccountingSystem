import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { ErrorHandlerService } from './shared/services/error-handler.service';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './shared/guards/auth/authguard';
import { SkillComponent } from './skill/skill.component';
import { SkillCategoryComponent } from './skillCategory/skillCategory.component';
import { KnowledgeLevelComponent } from './knowledgeLevel/knowledgeLevel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ManagerGuard } from './shared/guards/admin/managerGuard';
import { ProfileComponent } from './profile/profile.component';
import { RoleComponent } from './role/role.component';
import { SearchComponent } from './search/search.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserComponent,
    SkillComponent,
    SkillCategoryComponent,
    KnowledgeLevelComponent, 
    ForbiddenComponent,
    ProfileComponent,
    RoleComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
      { path: 'user', component: UserComponent, canActivate: [AuthGuard] },
      { path: 'skills', component: SkillComponent, canActivate: [AuthGuard, ManagerGuard]},
      { path: 'skillcategories', component: SkillCategoryComponent, canActivate: [AuthGuard, ManagerGuard]},
      { path: 'knowledgelevels', component: KnowledgeLevelComponent, canActivate: [AuthGuard, ManagerGuard]},
      { path: 'forbidden', component: ForbiddenComponent },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]  },
      { path: 'roles', component: RoleComponent, canActivate: [AuthGuard, ManagerGuard]},
      { path: 'search', component: SearchComponent, canActivate: [AuthGuard, ManagerGuard]}
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44335"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
