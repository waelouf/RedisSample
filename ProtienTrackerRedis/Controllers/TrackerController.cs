using ProtienTrackerRedis.Models;
using System.Web.Mvc;
using ServiceStack.Redis;

namespace ProtienTrackerRedis.Controllers
{
	public class TrackerController : Controller
    {
        // GET: Tracker
        public ActionResult Index(long userId, int amount = 0)
        {
			User user = null;
			using (IRedisClient client = new RedisClient())
			{
				var userClient = client.As<User>();
				user = userClient.GetById(userId);
				var historyClient = client.As<int>();
				var historyList = historyClient.Lists["urn:history" + userId];

				if (amount > 0)
				{
					user.Total += amount;
					userClient.Store(user);

					
					historyList.Prepend(amount);
					historyList.Trim(0, 4);

					client.AddItemToSortedSet("urn:leaderboard", user.Name, user.Total);
				}

				ViewBag.HistoryItems = historyList.GetAll();
			}

			return View(user);
        }
    }
}