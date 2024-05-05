import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../app/components/login/login.component';
import { MutualMatchesListComponent } from '../app/components/mutual-matches-list/mutual-matches-list.component';
import { MatchingComponent } from '../app/components/potential-matches-list/potential-matches-list.component';
import { ProfileComponent } from '../app/components/profile/profile.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'mutual-matches', component: MutualMatchesListComponent },
  { path: 'potential-matches', component: MatchingComponent },
  { path: 'profile', component: ProfileComponent },
];

/*

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

*/
