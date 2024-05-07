import { Component } from '@angular/core';
import { RouterModule, RouterOutlet, provideRouter } from '@angular/router';

import { MatSlideToggle } from "@angular/material/slide-toggle";
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import { ProfileComponent } from './components/profile/profile.component';



@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [MatMenuModule, MatToolbarModule, MatButtonModule, MatIconModule, MatSlideToggle, RouterModule, RouterOutlet, ProfileComponent]
})
export class AppModule { 
  title = "Your DatingApp"
}


