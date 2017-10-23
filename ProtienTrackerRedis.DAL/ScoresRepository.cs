using ServiceStack.Redis;
using ServiceStack.Redis.Support;
using System.Collections.Generic;
using System.Linq;

namespace ProtienTrackerRedis.DAL
{
	public class ScoresRepository
	{
		public IEnumerable<KeyValuePair<string, double>> GetScoreFromList(string listName)
		{
			IEnumerable<KeyValuePair<string, double>> leaderboard;
			using (IRedisClient client = new RedisClient())
			{
				var val = (OrderedDictionary<string, double>)client.GetAllWithScoresFromSortedSet(listName);
				leaderboard = val.OrderByDescending(x => x.Value);
			}

			return leaderboard;
		}

	}
}
