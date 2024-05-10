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

  likeUser(userId: Number): void {
    this.matchService.likeProfile(Number(userId)).subscribe({
      next: () => {
        // Optionally, refresh the list of potential matches or update the UI
      },
      error: (error) => console.error('Error liking user', error)
    });
  }

  dislikeUser(userId: number): void {
    this.matchService.dislikeProfile(Number(userId)).subscribe({
      next: () => {
        // Optionally, refresh the list of potential matches or update the UI
      },
      error: (error) => console.error('Error disliking user', error)
    });
  }
}
