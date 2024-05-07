import { Component, OnInit } from '@angular/core';
import { MatchingService } from '../../services/matching.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-matching',
  standalone: true,
  templateUrl: './potential-matches-list.component.html',
  styleUrls: ['./potential-matches-list.component.css'],
  imports: [CommonModule]
})
export class MatchingComponent implements OnInit {
  profiles: any[] = [];

  constructor(private matchingService: MatchingService) { }

  ngOnInit() {
    this.loadProfiles();
  }

  // Loads the profiles to be displayed
  loadProfiles(): void {
    this.matchingService.getProfiles().subscribe({
      next: (profiles) => this.profiles = profiles,
      error: (err) => console.error('Failed to load profiles', err)
    });
  }

  // Handles the 'Like' action
  likeProfile(profileId: number): void {
    this.matchingService.likeProfile(profileId).subscribe({
      complete: () => this.profiles = this.profiles.filter(p => p.id !== profileId)
    });
  }

  // Handles the 'Dislike' action
  dislikeProfile(profileId: number): void {
    this.matchingService.dislikeProfile(profileId).subscribe({
      complete: () => this.profiles = this.profiles.filter(p => p.id !== profileId)
    });
  }
}
