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

		public ActionResult Save(string userName, int goal, long? userId)
		{
			User user = null;
			
			using (IRedisClient client = new RedisClient())
			{
				var userClient = client.As<User>();
				if (userId.HasValue)
				{
					user = userClient.GetById(userId.Value);
				}
				else
				{
					user = new User
					{
						
						Id = userClient.GetNextSequence()
					};
				}

				user.Name = userName;
				user.Goal = goal;

				userClient.Store(user);

				userId = user.Id;
			}

			return RedirectToAction("Index", "Tracker", new { userId });
		}

		public ActionResult Edit(long userId)
		{
			User user = null;
			using (IRedisClient client = new RedisClient())
			{
				var userClient = client.As<User>();
				user = userClient.GetById(userId);
			}

			return View("NewUser", user);
		}
	}
}