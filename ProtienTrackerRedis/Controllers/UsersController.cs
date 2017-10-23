using System.Web.Mvc;
using ProtienTrackerRedis.Business;
using ProtienTrackerRedis.Entities;

namespace ProtienTrackerRedis.Controllers
{
	public class UsersController : Controller
	{
		private UsersBusiness _users;

		public UsersController()
		{
			_users = new UsersBusiness();
		}

		// GET: Users
		public ActionResult NewUser()
		{
			return View(new User());
		}

		public ActionResult Save(string userName, int goal, long? userId)
		{
			User user = new User();

			if (userId.Value > 0)
			{
				user = _users.Get(userId.Value);
			}
			
			user.Name = userName;
			user.Goal = goal;

			if (userId.HasValue)
			{
				_users.Update(user);
			}
			else
			{
				user = _users.Add(user);
			}
			
			userId = user.Id;

			return RedirectToAction("Index", "Tracker", new { userId });
		}

		public ActionResult Edit(long userId)
		{
			User user = _users.Get(userId);
			
			return View("NewUser", user);
		}
	}
}