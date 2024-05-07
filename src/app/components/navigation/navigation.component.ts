import { Component } from '@angular/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [MatSnackBarModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})
export class NavigationComponent {

}
