import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../services/profile.service';
import { AuthenticationService } from '../../services/auth.service';
import { Profile } from '../../models/profile';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatDatepickerToggle, MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule, NativeDateAdapter } from '@angular/material/core';
import { MatDateRangePicker } from '@angular/material/datepicker';


@Component({
  selector: 'app-profile',
  standalone: true,
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [NativeDateAdapter],
  imports: [
    CommonModule, MatButtonModule, MatInputModule, FormsModule, MatFormFieldModule, 
    MatLabel, MatDatepickerModule, MatDatepickerToggle, MatNativeDateModule,
  ]
})
export class ProfileComponent implements OnInit {
  profile: Profile | null = null;

  constructor(
    private profileService: ProfileService,
    private authService: AuthenticationService, // Add the AuthenticationService
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    const userId = this.authService.getCurrentUserId();
    if (userId === null || userId === -1) {  // Add a check for -1 if continuing to use it
      console.error('Invalid or no user ID found');
      this.router.navigate(['/login']);  // Redirect to login or show an error message
      return;
    }
    this.profileService.getProfile(userId).subscribe({
      next: (data) => this.profile = data,
      error: (error) => console.error('Failed to load profile', error)
    });
  }
  
  updateProfile(): void {
    if (this.profile) {
      this.profileService.updateProfile(this.profile.pid, this.profile).subscribe({
        next: (updatedProfile) => this.profile = updatedProfile,
        error: (error) => console.error('Failed to update profile', error)
      });
    }
  }

  deleteProfile(): void {
    if (this.profile) {
      this.profileService.deleteProfile(this.profile.pid).subscribe({
        next: () => this.router.navigate(['/login']),
        error: (error) => console.error('Failed to delete profile', error)
      });
    }
  }
}
