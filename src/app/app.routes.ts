import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../app/components/login/login.component';
import { MutualMatchesListComponent } from '../app/components/mutual-matches-list/mutual-matches-list.component';
import { MatchingComponent } from '../app/components/potential-matches-list/potential-matches-list.component';
import { ProfileComponent } from '../app/components/profile/profile.component';
import { provideRouter } from '@angular/router';
import { NavigationComponent } from './components/navigation/navigation.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent, title: 'Login Page'},
  { path: 'mutual-matches', component: MutualMatchesListComponent, title: 'List of matches' },
  { path: 'potential-matches', component: MatchingComponent, title: 'Find a Match' },
  { path: 'profile', component: ProfileComponent, title: 'Profile' },
  { path: 'navigation', component: NavigationComponent, title: 'Menu' },
];

