import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // For making HTTP requests globally
import { ProfileService } from './services/profile.service';
import { UserProfile } from './models/profile'; 

import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';

import { MatSlideToggle } from "@angular/material/slide-toggle";
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import { ProfileComponent } from './components/profile/profile.component';
import { NavigationComponent } from './components/navigation/navigation.component';


@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [MatMenuModule, MatToolbarModule, MatButtonModule, MatIconModule, MatSlideToggle, RouterModule, RouterOutlet, ProfileComponent]
})
export class AppModule { }
