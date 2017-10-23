using ProtienTrackerRedis.DAL;
using ProtienTrackerRedis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtienTrackerRedis.Business
{
	public class UsersBusiness : IDisposable
	{
		private bool disposed = false;

		private RedisRepository<User> _repository;

		public UsersBusiness()
		{
			_repository = new RedisRepository<User>();
		}

		public User Add(User user)
		{
			return _repository.Add(user);
		}

		public User Update(User user)
		{
			return _repository.Update(user);
		}

		public User Get(long userId)
		{
			return _repository.Get(userId);
		}

		public IEnumerable<User> GetAll()
		{
			return _repository.GetAll();
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
					_repository = null;
				}

				disposed = true;
			}
		}

		~UsersBusiness()
		{
			Dispose(false);
		}
	}
}
