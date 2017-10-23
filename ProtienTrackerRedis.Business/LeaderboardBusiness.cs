using ProtienTrackerRedis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtienTrackerRedis.Business
{
	public class LeaderboardBusiness
	{
		private ScoresRepository _repo;

		public LeaderboardBusiness()
		{
			_repo = new ScoresRepository();
		}

		public IEnumerable<KeyValuePair<string, double>> GetLeaderboard()
		{
			return _repo.GetScoreFromList(Utilities.Constans.HistoryListName);
		}
	}
}
