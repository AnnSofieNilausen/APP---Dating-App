import { Component, OnInit, ViewChild} from '@angular/core';
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
import { NgForm } from '@angular/forms';

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
  profile: Profile = {
    pid: 0,
    Fname: '',
    Lname: '',
    Dob: new Date(),
    Gender: '',
    Aol: '',
    Username: '',
    SexualOrientation: '',
    Bio: '',
    SearchingFor: '',
    Interests: '',
    Occupation: '',
    Pictures: '',
    Likes: 0,
    Matches: 0,
    Instagram: '',
    Snapchat: ''
  };

    @ViewChild('profileForm') profileForm!: NgForm;

    constructor(
      private profileService: ProfileService,
      private authService: AuthenticationService,
      private router: Router
    ) {}
  
    ngOnInit(): void {
      this.loadProfile();
    }
  
    loadProfile(): void {
      const userId = this.authService.getCurrentUserId();
      if (userId !== null) {
        this.profileService.getProfile(userId).subscribe({
          next: (data) => this.profile = data,
          error: (error) => {
            console.error('Failed to load profile', error);
            this.router.navigate(['/login']);
          }
        });
      } else {
        this.router.navigate(['/login']);
      }
    }
  
    updateProfile(): void {
      if (this.profile && this.profileForm.valid) {
        this.profileService.updateProfile(this.profile.pid, this.profile).subscribe({
          next: (updatedProfile) => {
            this.profile = updatedProfile;
            console.log('Profile updated:', this.profile);
          },
          error: (error) => console.error('Failed to update profile', error)
        });
      }
    }
  }