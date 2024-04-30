import { Component, OnInit } from '@angular/core';
import { MatchingService } from '../services/matching.service'; // Ensure the correct path

@Component({
  selector: 'app-matching',
  templateUrl: './matching.component.html',
  styleUrls: ['./matching.component.css']
})
export class MatchingComponent implements OnInit {
  currentProfile: any = null;

  constructor(private matchingService: MatchingService) { }

  ngOnInit() {
    this.loadNextProfile();
  }

  // Loads the next profile to be displayed
  loadNextProfile(): void {
    this.matchingService.getNextProfile().subscribe({
      next: (profile) => this.currentProfile = profile,
      error: (err) => console.error('Failed to load profile', err)
    });
  }

  // Handles the 'Like' action
  likeProfile(): void {
    this.matchingService.likeProfile(this.currentProfile.id).subscribe({
      complete: () => this.loadNextProfile() // Load next profile after liking
    });
  }

  // Handles the 'Dislike' action
  dislikeProfile(): void {
    this.matchingService.dislikeProfile(this.currentProfile.id).subscribe({
      complete: () => this.loadNextProfile() // Load next profile after disliking
    });
  }
}
