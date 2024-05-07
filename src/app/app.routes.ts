import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import { MutualMatchesListComponent } from './components/mutual-matches-list/mutual-matches-list.component';
import { MatchingComponent } from './components/potential-matches-list/potential-matches-list.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
  { path: 'profile', component: ProfileComponent },
  { path: 'mutual-matches', component: MutualMatchesListComponent },
  { path: 'potential-matches', component: MatchingComponent },
  {path: 'login', component: LoginComponent},
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  //{ path: '', redirectTo: '/profile', pathMatch: 'full' } // Redirect to profile by default
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }