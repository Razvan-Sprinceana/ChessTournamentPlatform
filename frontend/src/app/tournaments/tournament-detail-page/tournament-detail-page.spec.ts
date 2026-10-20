import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TournamentDetailPage } from './tournament-detail-page';

describe('TournamentDetailPage', () => {
  let component: TournamentDetailPage;
  let fixture: ComponentFixture<TournamentDetailPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TournamentDetailPage],
    }).compileComponents();

    fixture = TestBed.createComponent(TournamentDetailPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
