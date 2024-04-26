import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { StudentListComponent } from "./student-list/student-list.component";

import { MatSlideToggle } from "@angular/material/slide-toggle";
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [MatMenuModule, MatToolbarModule, MatButtonModule, MatIconModule, MatSlideToggle, RouterModule, RouterOutlet, StudentComponent, StudentListComponent]
})
export class AppComponent {
  title = 'Lecture05';
}
