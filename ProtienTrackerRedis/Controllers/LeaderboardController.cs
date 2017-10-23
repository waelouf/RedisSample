using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Redis;
using ServiceStack.Redis.Support;
namespace ProtienTrackerRedis.Controllers
{
    public class LeaderboardController : Controller
    {
        // GET: Leaderboard
        public ActionResult Index()
        {
			IEnumerable<KeyValuePair<string, double>> leaderboard ;
			using (IRedisClient client = new RedisClient())
			{
				var val = (OrderedDictionary < string, double> )client.GetAllWithScoresFromSortedSet("urn:leaderboard");
				leaderboard = val.OrderByDescending(x => x.Value);
			}

            return View(leaderboard);
        }
    }
}