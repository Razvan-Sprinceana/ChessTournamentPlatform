import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TournamentListItem } from '../models/tournament';

@Injectable({
  providedIn: 'root',
})
export class TournamentService {
    private readonly http = inject(HttpClient);
    private readonly baseUrl = `${environment.apiBaseUrl}/api/tournaments`;

    getTournaments(): Observable<TournamentListItem[]> {
        return this.http.get<TournamentListItem[]>(this.baseUrl);
    }
}
