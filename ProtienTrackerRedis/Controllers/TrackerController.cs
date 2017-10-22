using ProtienTrackerRedis.Models;
using System.Web.Mvc;
using ServiceStack.Redis;

namespace ProtienTrackerRedis.Controllers
{
	public class TrackerController : Controller
    {
        // GET: Tracker
        public ActionResult Index(long userId)
        {
			User user = null;
			using (IRedisClient client = new RedisClient())
			{
				var userClient = client.As<User>();
				user = userClient.GetValue(userId.ToString());
			}

			return View(user);
        }
    }
}