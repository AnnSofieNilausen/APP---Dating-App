import { Component, OnInit } from '@angular/core';
import { PotentialMatch } from '../model/potential-match';
import { MatchingService } from '../service/matching.service';

@Component({
  selector: 'app-potential-matches-list',
  templateUrl: './potential-matches-list.component.html',
  styleUrls: ['./potential-matches-list.component.css']
})
export class PotentialMatchesListComponent implements OnInit {
  potentialMatches: PotentialMatch[] = [];

  constructor(private matchingService: MatchingService) {}

  ngOnInit(): void {
    this.matchingService.getPotentialMatches().subscribe((matches) => {
      this.potentialMatches = matches;
    });
  }
}
