using ProtienTrackerRedis.DAL;
using System.Collections.Generic;

namespace ProtienTrackerRedis.Business
{
	public class LeaderboardBusiness
	{
		private ScoresRepository _repo;

		public LeaderboardBusiness()
		{
			_repo = new ScoresRepository(Utilities.Constans.LeaderboardListName);
		}

		public IEnumerable<KeyValuePair<string, double>> GetLeaderboard()
		{
			return _repo.GetScoreFromList();
		}
	}
}
