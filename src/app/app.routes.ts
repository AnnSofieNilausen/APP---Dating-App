import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import { MutualMatchesListComponent } from './components/mutual-matches-list/mutual-matches-list.component';
import { MatchingComponent } from './components/potential-matches-list/potential-matches-list.component';

export const routes: Routes = [
  { path: 'profile', component: ProfileComponent },
  { path: 'mutual-matches', component: MutualMatchesListComponent },
  { path: 'potential-matches', component: MatchingComponent },
  { path: '', redirectTo: '/profile', pathMatch: 'full' } // Redirect to profile by default
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }