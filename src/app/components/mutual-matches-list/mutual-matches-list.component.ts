import { Component, OnInit } from '@angular/core';
import { MutualMatch } from '../model/mutual-match';
import { MatchesService } from '../service/matches.service';

@Component({
  selector: 'app-mutual-matches-list',
  templateUrl: './mutual-matches-list.component.html',
  styleUrls: ['./mutual-matches-list.component.css']
})
export class MutualMatchesListComponent implements OnInit {
  mutualMatches: MutualMatch[] = [];

  constructor(private matchesService: MatchesService) {}

  ngOnInit(): void {
    this.matchesService.getMutualMatches().subscribe((matches) => {
      this.mutualMatches = matches;
    });
  }
}
