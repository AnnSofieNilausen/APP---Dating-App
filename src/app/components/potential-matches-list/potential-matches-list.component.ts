import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match.service';
import { Profile } from '../../models/profile';
import { CommonModule, NgIf } from '@angular/common';

@Component({
  selector: 'app-matching',
  standalone: true,
  templateUrl: './potential-matches-list.component.html',
  styleUrls: ['./potential-matches-list.component.css'],
  imports: [CommonModule, NgIf]
})
export class MatchingComponent implements OnInit {
  currentProfile: Profile | null = null;  // Store single profile object

  constructor(private matchService: MatchService) {}

  ngOnInit(): void {
    this.loadNextProfile();
  }

  loadNextProfile(): void {
    this.matchService.getPotentialMatches().subscribe({
      next: (profile) => {
        this.currentProfile = profile;
        console.log('Loaded profile:', this.currentProfile);
      },
      error: (error) => {
        console.error('Failed to load potential profile', error);
        this.currentProfile = null;
      }
    });
  }

  likeUser(): void {
    if (this.currentProfile) {
      this.matchService.likeProfile(this.currentProfile.pid).subscribe({
        next: () => this.loadNextProfile(),
        error: (error) => console.error('Error liking user', error)
      });
    }
  }

  dislikeUser(): void {
    if (this.currentProfile) {
      this.matchService.dislikeProfile(this.currentProfile.pid).subscribe({
        next: () => this.loadNextProfile(),
        error: (error) => console.error('Error disliking user', error)
      });
    }
  }
}
