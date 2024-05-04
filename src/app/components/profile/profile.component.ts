import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule, ReactiveFormsModule, } from '@angular/forms';
import { ProfileService } from "/Users/annsofienilausen/Desktop/APP---Dating-App2/Angular2/src/app/services/profile.service";
import { provideNativeDateAdapter } from '@angular/material/core';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule} from '@angular/material/datepicker';


@Component({
  selector: 'app-profile',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [MatDatepickerModule, ReactiveFormsModule, MatButtonModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profileForm: FormGroup; // This FormGroup will contain our form data and validation rules

  constructor(
    private profileService: ProfileService, private router: Router, // Inject the ProfileService for HTTP operations
    private fb: FormBuilder // Inject FormBuilder for form creation
  ) 
  
  {// Initialize the form group with default values and validators
    this.profileForm = this.fb.group({
      fname: ['', Validators.required],
      lname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      bio: ['']
    });}

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
