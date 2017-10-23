using ProtienTrackerRedis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtienTrackerRedis.Business
{
	public class TrackerBusiness : IDisposable
	{
		private bool disposed = false;

		private UsersBusiness _usersBusiness;
		private ListRepository _historyList;
		private ScoresRepository _leaderboardSet;
		private long _userId;

		public TrackerBusiness(long userId)
		{
			_userId = userId;
			_usersBusiness = new UsersBusiness();
			_historyList = new ListRepository(Utilities.Constans.HistoryListNamePrefix + _userId);
			_leaderboardSet = new ScoresRepository(Utilities.Constans.LeaderboardListName);
		}

		public void UpdateAmount(int amount)
		{
			var user = _usersBusiness.Get(_userId);
			user.Total += amount;
			_usersBusiness.Update(user);

			_leaderboardSet.AddScore(user.Name, user.Total);
			_historyList.AddToList(amount);
			_historyList.LimitList(5);
		}

		public IList<int> GetHistoryList()
		{
			return _historyList.GetAll();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_usersBusiness = null;
				}

				disposed = true;
			}
		}
	}
}
