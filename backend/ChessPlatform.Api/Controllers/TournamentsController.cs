using ChessPlatform.Api.Data;
using ChessPlatform.Api.Dtos;
using ChessPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChessPlatform.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TournamentsController : ControllerBase
	{
		private readonly TournamentService tournamentService;
		public TournamentsController(TournamentService tournamentService)
		{
			this.tournamentService = tournamentService;
		}
		[HttpGet]
		public async Task<ActionResult<List<TournamentDto>>> GetTournaments(CancellationToken cancellationToken)
		{
			var tournaments = await tournamentService.GetTournamentsAsync(cancellationToken);
			return Ok(tournaments);
		}
	}
}
