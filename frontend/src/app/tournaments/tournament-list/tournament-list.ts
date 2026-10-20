import { DatePipe } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { TournamentService } from '../../services/tournament';
import { TournamentListItem } from '../../models/tournament';
import { RouterLink } from '@angular/router';

@Component({
  imports: [DatePipe, RouterLink],
  selector: 'app-tournament-list',
  styleUrl: './tournament-list.scss',
  templateUrl: './tournament-list.html',
})
export class TournamentList implements OnInit {
  private readonly tournamentService = inject(TournamentService);

  protected readonly tournaments = signal<TournamentListItem[]>([]);
  protected readonly loading = signal(true);
  protected readonly error = signal<string | null>(null);

  ngOnInit(): void {
    this.tournamentService.getTournaments().subscribe({
      next: (data) => {
        this.tournaments.set(data);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set('Could not load tournaments.');
        this.loading.set(false);
      },
    });
  }
}
