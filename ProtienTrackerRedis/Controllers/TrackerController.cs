using System.Web.Mvc;
using ProtienTrackerRedis.Business;

namespace ProtienTrackerRedis.Controllers
{
	public class TrackerController : Controller
	{
		private TrackerBusiness _tracker;
		private UsersBusiness _users;

		public TrackerController()
		{
			_users = new UsersBusiness();
		}

		// GET: Tracker
		public ActionResult Index(long userId, int amount = 0)
		{
			_tracker = new TrackerBusiness(userId);

			if (amount > 0)
			{
				_tracker.UpdateAmount(amount);
			}

			var user = _users.Get(userId);
			ViewBag.HistoryItems = _tracker.GetHistoryList();
			
			return View(user);
		}
	}
}