import { Routes } from '@angular/router';
import { TournamentList } from './tournaments/tournament-list/tournament-list';
import { TournamentDetailPage } from './tournaments/tournament-detail-page/tournament-detail-page';

export const routes: Routes = [
  { path: '', component: TournamentList },
  { path: 'tournaments/:id', component: TournamentDetailPage },
  { path: '**', redirectTo: '' }
];