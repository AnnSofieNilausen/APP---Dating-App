import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../services/profile.service';
import { Profile } from '../../models/profile';
import { CommonModule } from '@angular/common';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatDatepicker, MatDatepickerToggle } from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-profile',
  standalone: true,
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  imports: [CommonModule, FormsModule, MatFormField, MatDatepicker, MatLabel, MatDatepickerToggle]
})
export class ProfileComponent implements OnInit {
  profile: Profile | null = null;

  constructor(
    private profileService: ProfileService,
    private router: Router,
    private route: ActivatedRoute // Import ActivatedRoute
  ) {}

  ngOnInit(): void {
    // Check for navigation state profile first
    this.route.paramMap.subscribe(params => {
      const routerState = this.router.getCurrentNavigation()?.extras.state;
      if (routerState && routerState['profile']) {
        this.profile = routerState['profile'];
      } else {
        // If no navigation state, load profile normally
        this.loadProfile();
      }
    });
  }

  loadProfile(): void {
    this.profileService.getProfile(1).subscribe({
      next: (data) => this.profile = data,
      error: (error) => console.error('Failed to load profile', error)
    });
  }

  updateProfile(): void {
    if (this.profile) {
      const pidNumber = Number(this.profile.ID); // Convert pid to number if necessary
      this.profileService.updateProfile(pidNumber, this.profile).subscribe({
        next: (updatedProfile) => this.profile = updatedProfile,
        error: (error) => console.error('Failed to update profile', error)
      });
    }
  }

  deleteProfile(): void {
    if (this.profile) {
      const pidNumber = Number(this.profile.ID);
      this.profileService.deleteProfile(pidNumber).subscribe({
        next: () => this.router.navigate(['/login']),
        error: (error) => console.error('Failed to delete profile', error)
      });
    }
  }
}
