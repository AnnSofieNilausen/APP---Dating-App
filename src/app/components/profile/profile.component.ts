// profile.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { ProfileService } from '../../services/profile.service';
import { UserProfile } from '../../models/profile';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-profile',
  standalone: true,
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  imports: [CommonModule, MatFormField, MatLabel, FormsModule, ReactiveFormsModule],
})
export class ProfileComponent implements OnInit {
  @Input() id!: number;  // Input property to receive id from parent component
  userProfile!: UserProfile;

  constructor(private profileService: ProfileService, private router: Router) {}

  ngOnInit() {
    this.loadProfile();
  }

  loadProfile() {
    this.profileService.getProfile(this.id).subscribe({
      next: (profile) => {
        this.userProfile = profile;
      },
      error: (err) => console.error('Failed to load profile', err)
    });
  }

  updateProfile() {
    this.profileService.updateProfile(this.userProfile).subscribe({
      next: () => {
        console.log('Profile updated successfully');
        // Optionally redirect or perform additional actions
        this.router.navigate(['/profile']);  // Example redirection
      },
      error: (err) => console.error('Error updating profile:', err)
    });
  }

  deleteProfile() {
    this.profileService.deleteProfile(this.userProfile.id).subscribe({
      next: () => {
        console.log('Profile deleted successfully');
        this.router.navigate(['/']);  // Redirect to home or another appropriate route
      },
      error: (err) => console.error('Error deleting profile:', err)
    });
  }
}
