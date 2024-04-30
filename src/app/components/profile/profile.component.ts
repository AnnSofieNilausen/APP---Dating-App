import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfileService } from '../services/ProfileService'; // Ensure the correct path to your service

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profileForm: FormGroup; // This FormGroup will contain our form data and validation rules

  constructor(
    private profileService: ProfileService, // Inject the ProfileService for HTTP operations
    private fb: FormBuilder // Inject FormBuilder for form creation
  ) {}

  ngOnInit(): void {
    this.loadUserProfile();
  }

  // Fetches the user profile from the backend and initializes the form
  loadUserProfile(): void {
    this.profileService.getProfile(1) // Assuming '1' is the user ID, replace as needed
      .subscribe({
        next: (profile) => this.initForm(profile),
        error: (err) => console.error('Error fetching profile', err)
      });
  }

  // Initializes the form group with data fetched from the server and sets validation rules
  initForm(profile: any): void {
    this.profileForm = this.fb.group({
      fname: [profile.fname, Validators.required], // 'fname' field required
      lname: [profile.lname, Validators.required], // 'lname' field required
      email: [profile.email, [Validators.required, Validators.email]], // 'email' must be valid and required
      bio: [profile.bio] // 'bio' field is optional
      // Add other fields as necessary
    });
  }

  // Handles form submission
  onSubmit(): void {
    if (this.profileForm.valid) {
      this.profileService.updateProfile(this.profileForm.value)
        .subscribe({
          next: () => console.log('Profile updated successfully!'),
          error: (err) => console.error('Failed to update profile', err)
        });
    } else {
      console.log('Form is not valid'); // Log or handle invalid form cases
    }
  }
}
