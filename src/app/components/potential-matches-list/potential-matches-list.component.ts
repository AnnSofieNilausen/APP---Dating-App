// src/app/matching/matching.component.ts

import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match.service';
import { Profile } from '../../models/profile';
import { CommonModule, NgIf } from '@angular/common';

@Component({
  selector: 'app-matching',
  standalone: true,
  templateUrl: './potential-matches-list.component.html', // relative path to the HTML template
  styleUrls: ['./potential-matches-list.component.css'], // relative path to the CSS file
  imports: [CommonModule, NgIf]
})
export class MatchingComponent implements OnInit {
  potentialMatches: Profile[] = [];

  constructor(private matchService: MatchService) {}

  ngOnInit(): void {
    this.loadPotentialMatches();
  }

  loadPotentialMatches(): void {
    this.matchService.getPotentialMatches().subscribe({
      next: (matches) => this.potentialMatches = matches,
      error: (error) => console.error('Failed to load potential matches', error)
    });
  }

  likeUser(userId: number): void {
    this.matchService.likeProfile(userId).subscribe({
      next: () => {
        this.potentialMatches.shift(); // Remove the liked user from the array
        this.loadNextMatch(); // Load next user
      },
      error: (error) => console.error('Error liking user', error)
    });
  }

  dislikeUser(userId: number): void {
    this.matchService.dislikeProfile(userId).subscribe({
      next: () => {
        this.potentialMatches.shift(); // Remove the disliked user from the array
        this.loadNextMatch(); // Load next user
      },
      error: (error) => console.error('Error disliking user', error)
    });
  }

  loadNextMatch(): void {
    this.matchService.getPotentialMatches().subscribe({
      next: (matches) => {
        if (matches.length > 0) {
          this.potentialMatches.push(matches[0]); // Assume backend sends the next match
        }
      },
      error: (error) => console.error('Failed to load next match', error)
    });
  }
}
