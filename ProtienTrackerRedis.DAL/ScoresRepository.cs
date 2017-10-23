using ServiceStack.Redis;
using ServiceStack.Redis.Support;
using System.Collections.Generic;
using System.Linq;

namespace ProtienTrackerRedis.DAL
{
	public class ScoresRepository
	{
		private string _listName;

		public ScoresRepository(string listName)
		{
			_listName = listName;
		}

		public IEnumerable<KeyValuePair<string, double>> GetScoreFromList()
		{
			IEnumerable<KeyValuePair<string, double>> leaderboard;
			using (IRedisClient client = new RedisClient())
			{
				var val = (OrderedDictionary<string, double>)client.GetAllWithScoresFromSortedSet(_listName);
				leaderboard = val.OrderByDescending(x => x.Value);
			}

			return leaderboard;
		}

		public void AddScore(string key, int score)
		{
			using (IRedisClient client = new RedisClient())
			{
				client.AddItemToSortedSet(_listName, key, score);

			}
		}

	}
}
