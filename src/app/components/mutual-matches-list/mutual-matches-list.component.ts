import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatchesService } from '../../services/matches.service';
import { MutualMatch } from '../../models/mutual-match';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mutual-matches-list',
  standalone: true,
  templateUrl: './mutual-matches-list.component.html',
  styleUrls: ['./mutual-matches-list.component.css'],
  imports: [CommonModule],
})
export class MutualMatchesListComponent implements OnInit {
  // Component properties
  mutualMatches: MutualMatch[] = []; // Array to hold mutual matches fetched from the server
  userId: number | undefined; // To store the user ID passed through the route

  // Constructor with dependency injection
  constructor(
    private matchesService: MatchesService, // Injecting the MatchesService to fetch match data
    private route: ActivatedRoute // Injecting ActivatedRoute to access route parameters
  ) {}

  // OnInit lifecycle hook
  ngOnInit(): void {
    // Subscribe to route parameters
    this.route.params.subscribe(params => {
      this.userId = +params['userId']; // Extracting the user ID from route parameters and converting it to a number
      this.loadMutualMatches(); // Calling the function to load mutual matches after getting the user ID
    });
  }

  // Function to load mutual matches for a given user
  loadMutualMatches(): void {
    if (this.userId) {
      this.matchesService.getMutualMatches(this.userId).subscribe({
        next: (matches) => this.mutualMatches = matches, // Success callback: store fetched matches in the array
        error: (err) => console.error('Failed to load mutual matches', err) // Error callback: log any errors that occur during fetching
      });
    }
  }

  // Function to delete a specific match
  deleteMatch(matchId: number): void {
    if (this.userId) {
      this.matchesService.deleteMatch(this.userId, matchId).subscribe({
        next: () => this.mutualMatches = this.mutualMatches.filter(match => match.id !== matchId), // Success callback: update the matches array by filtering out the deleted match
        error: (err) => console.error('Error deleting match', err) // Error callback: log any errors that occur during the delete operation
      });
    }
  }
}