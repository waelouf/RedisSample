using ProtienTrackerRedis.DAL.Abstract;
using ServiceStack.Redis;
using ProtienTrackerRedis.Entities;
using System.Collections.Generic;

namespace ProtienTrackerRedis.DAL
{
	public class RedisRepository<T> : IRepository<T>  where T : BaseEntity
	{	
		public T Add(T t)
		{
			using (IRedisClient client = new RedisClient())
			{
				var genericClient = client.As<T>();
				t.Id = genericClient.GetNextSequence();
				t = genericClient.Store(t);
			}

			return t;
		}

		public void Delete(T t)
		{
			DeleteByKey(t.Id);
		}

		public void DeleteByKey(long key)
		{
			using (IRedisClient client = new RedisClient())
			{
				var genericClient = client.As<T>();
				genericClient.DeleteById(key);
			}
		}

		public T Get(long id)
		{
			T t = null;
			using (IRedisClient client = new RedisClient())
			{
				var genericClient = client.As<T>();
				t = genericClient.GetById(id);
			}

			return t;
		}

		public IEnumerable<T> GetAll()
		{
			IList<T> t = null;
			using (IRedisClient client = new RedisClient())
			{
				var genericClient = client.As<T>();
				t = genericClient.GetAll();
			}

			return t;
		}

		public T Update(T t)
		{
			using (IRedisClient client = new RedisClient())
			{
				var genericClient = client.As<T>();
				t = genericClient.Store(t);
			}

			return t;
		}
	}
}
