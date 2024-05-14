import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match.service';
import { Profile } from '../../models/profile';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mutual-matches',
  standalone: true,
  templateUrl: './mutual-matches-list.component.html',
  styleUrls: ['./mutual-matches-list.component.css'],
  imports: [CommonModule]
})
export class MatchesComponent implements OnInit {
  mutualMatches: Profile[] = [];

  constructor(private matchService: MatchService) {}

  ngOnInit(): void {
    this.loadMutualMatches();
  }

  loadMutualMatches(): void {
    this.matchService.getCurrentMatches().subscribe({
      next: (matches) => this.mutualMatches = matches,
      error: (error) => console.error('Failed to load mutual matches', error)
    });
  }
}
