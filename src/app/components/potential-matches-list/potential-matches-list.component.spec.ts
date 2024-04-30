import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PotentialMatchesListComponent } from './potential-matches-list.component';

describe('PotentialMatchesListComponent', () => {
  let component: PotentialMatchesListComponent;
  let fixture: ComponentFixture<PotentialMatchesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PotentialMatchesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PotentialMatchesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
