// src/app/matches/matches.component.ts

import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match.service';
import { Profile } from '../../models/profile'; // Updated import
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mutual-matches-list',
  templateUrl: '../../components/mutual-matches-list/mutual-matches-list.component.html',
  styleUrls: ['./mutual-matches-list.component.css'],
  standalone: true,
  imports: [CommonModule] // Ensure CommonModule is imported
})
export class MatchesComponent implements OnInit {
  matches: Profile[] = [];  // Changed type from Match[] to Profile[]

  constructor(private matchService: MatchService) {}

  ngOnInit(): void {
    this.loadMatches();
  }

  loadMatches(): void {
    this.matchService.getCurrentMatches().subscribe({
      next: (matches) => this.matches = matches,
      error: (error) => console.error('Failed to load matches', error)
    });
  }

  deleteMatch(matchId: number): void {
    this.matchService.deleteMatch(matchId).subscribe({
      next: () => {
        // Optionally, refresh the list of matches or update the UI
        this.loadMatches();  // Reload the matches after deletion
      },
      error: (error) => console.error('Failed to delete match', error)
    });
  }
}
