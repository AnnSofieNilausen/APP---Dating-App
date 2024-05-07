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
    if (this.id) {
      this.profileService.getProfile(this.id).subscribe({
        next: (profile) => {
          this.userProfile = profile;
        },
        error: (err) => console.error('Failed to load profile', err)
      });
    }
  }

  updateProfile() {
    // Update profile logic here
    console.log('Profile updated');
  }
}
