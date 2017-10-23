using System.Web.Mvc;
using ProtienTrackerRedis.Business;

namespace ProtienTrackerRedis.Controllers
{
	public class HomeController : Controller
	{
		private UsersBusiness _users;

		public HomeController()
		{
			_users = new UsersBusiness();
		}

		public ActionResult Index()
		{
			var users = _users.GetAll();
			var userSelection = new SelectList(users, "Id", "Name", string.Empty);
			ViewBag.UserId = userSelection;
			
			return View();
		}


	}
}