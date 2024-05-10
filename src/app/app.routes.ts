// src/app/app-routing.module.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MatchingComponent } from './components/potential-matches-list/potential-matches-list.component';
import { MatchesComponent } from './components/mutual-matches-list/mutual-matches-list.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },  // Redirect to login
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'matching', component: MatchingComponent },
  { path: 'matches', component: MatchesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
