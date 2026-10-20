import { Component, OnInit, inject, input, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { RouterLink } from '@angular/router';
import { TournamentService } from '../../services/tournament';
import { TournamentDetailsModel } from '../../models/tournament';

@Component({
  selector: 'app-tournament-detail-page',
  imports: [DatePipe, RouterLink],
  templateUrl: './tournament-detail-page.html',
  styleUrl: './tournament-detail-page.scss'
})
export class TournamentDetailPage implements OnInit {
  private readonly tournamentService = inject(TournamentService);

  // Filled from the route parameter :id (thanks to withComponentInputBinding)
  readonly id = input.required<string>();

  protected readonly tournament = signal<TournamentDetailsModel | null>(null);
  protected readonly loading = signal(true);
  protected readonly notFound = signal(false);
  protected readonly error = signal<string | null>(null);

  ngOnInit(): void {
    const tournamentId = Number(this.id());

    if (!Number.isInteger(tournamentId)) {
      this.notFound.set(true);
      this.loading.set(false);
      return;
    }

    this.tournamentService.getTournament(tournamentId).subscribe({
      next: data => {
        this.tournament.set(data);
        this.loading.set(false);
      },
      error: (err: HttpErrorResponse) => {
        if (err.status === 404) {
          this.notFound.set(true);
        } else {
          this.error.set('Could not load this tournament.');
        }
        this.loading.set(false);
      }
    });
  }
}