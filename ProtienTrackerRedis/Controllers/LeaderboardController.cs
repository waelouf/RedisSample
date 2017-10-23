using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProtienTrackerRedis.Business;

namespace ProtienTrackerRedis.Controllers
{
	public class LeaderboardController : Controller
	{
		private LeaderboardBusiness _business;

		public LeaderboardController()
		{
			_business = new LeaderboardBusiness();
		}

		// GET: Leaderboard
		public ActionResult Index()
		{
			IEnumerable<KeyValuePair<string, double>> leaderboard;
			var val = _business.GetLeaderboard();
			leaderboard = val.OrderByDescending(x => x.Value);
			return View(leaderboard);
		}
	}
}