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
viewProfile(arg0: any) {
throw new Error('Method not implemented.');
}
  mutualMatches: MutualMatch[] = [];
  private userId: number | undefined;

  constructor(
    private matchesService: MatchesService,
    private route: ActivatedRoute  // Inject ActivatedRoute to access route parameters
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = +params['userId']; // '+' converts 'userId' from string to number
      this.loadMutualMatches();
    });
  }

  loadMutualMatches(): void {
    if (this.userId) {
      this.matchesService.getMutualMatches(this.userId).subscribe({
        next: (matches) => this.mutualMatches = matches,
        error: (err) => console.error('Failed to load mutual matches', err)
      });
    } else {
      console.error('User ID is undefined');
    }
  }
}
