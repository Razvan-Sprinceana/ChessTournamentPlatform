export type TournamentState = 'Draft' | 'RegistrationOpen' | 'InProgress' | 'Finished'

export interface TournamentListItem {
    id: number;
    name: string;
    startDate: string;
    endDate: string;
    state: TournamentState;
    organizerId: number;
    organizerName: string;
    numberOfRounds: number;
    minRating: number | null;
    maxRating: number | null;
    numberOfPlayers: number;
}