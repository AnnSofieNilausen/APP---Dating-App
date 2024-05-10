// src/app/app.component.ts

import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MatchesComponent } from './components/mutual-matches-list/mutual-matches-list.component';
import { MatchingComponent } from './components/potential-matches-list/potential-matches-list.component';
import { MatToolbar } from '@angular/material/toolbar';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuModule } from '@angular/material/menu';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'matching', component: MatchingComponent },
  { path: 'matches', component: MatchesComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [RouterModule, MatToolbar, MatIcon, MatMenu, MatMenuModule]
})
export class AppComponent {
  title = 'Dating App';
}
