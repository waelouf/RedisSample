using System.Web.Mvc;
using ServiceStack.Redis;
using ProtienTrackerRedis.Models;

namespace ProtienTrackerRedis.Controllers
{
	public class UsersController : Controller
    {
        // GET: Users
        public ActionResult NewUser()
        {
            return View();
        }

		public ActionResult Save(string userName, int goal)
		{
			using (IRedisClient client = new RedisClient())
			{
				var userClient = client.As<User>();
				var user = new User
				{
					Name = userName,
					Goal = goal,
					Id = userClient.GetNextSequence()
				};

				var userId = userClient.Store(user);

				return RedirectToAction("Index", "Home");
			}
		}
    }
}