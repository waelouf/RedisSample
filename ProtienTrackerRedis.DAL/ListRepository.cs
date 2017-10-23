using ServiceStack.Redis;
using System.Collections.Generic;

namespace ProtienTrackerRedis.DAL
{
	public class ListRepository
	{
		private string _listName;

		public ListRepository(string listName)
		{
			_listName = listName;
		}

		public void AddToList(int amount)
		{
			using (IRedisClient client = new RedisClient())
			{
				var historyClient = client.As<int>();
				var historyList = historyClient.Lists[_listName];
				historyList.Prepend(amount);
			}
		}

		public void LimitList(int limit)
		{
			using (IRedisClient client = new RedisClient())
			{
				var historyClient = client.As<int>();
				var historyList = historyClient.Lists[_listName];
				historyList.Trim(0, limit - 1);
			}
		}

		public IList<int> GetAll()
		{
			IList<int> result;
			using (IRedisClient client = new RedisClient())
			{
				var historyClient = client.As<int>();
				var historyList = historyClient.Lists[_listName];
				result = historyList.GetAll();
			}

			return result;
		}
	}

}
