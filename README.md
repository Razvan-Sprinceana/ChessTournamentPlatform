\# Chess Tournament Platform



A platform for organizing chess tournaments: player registration with rating limits, round pairings, result tracking and Elo rating calculation.



\## Tech stack



\- \*\*Backend:\*\* ASP.NET Core (.NET 10), Entity Framework Core

\- \*\*Database:\*\* SQL Server

\- \*\*Frontend:\*\* Angular \*(in progress)\*

\- \*\*Cloud \& CI/CD:\*\* AWS, GitHub Actions \*(planned)\*



\## Project structure



\- `backend/` – ASP.NET Core Web API

\- `frontend/` – Angular app \*(coming soon)\*



\## Running locally



1\. Install the .NET 10 SDK and SQL Server.

2\. Set the connection string in `backend/ChessPlatform.Api/appsettings.Development.json`.

3\. Apply migrations: `dotnet ef database update` (from `backend/ChessPlatform.Api`).

4\. Run the API: `dotnet run`.

