import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MutualMatchesListComponent } from './mutual-matches-list.component';

describe('MutualMatchesListComponent', () => {
  let component: MutualMatchesListComponent;
  let fixture: ComponentFixture<MutualMatchesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MutualMatchesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MutualMatchesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
