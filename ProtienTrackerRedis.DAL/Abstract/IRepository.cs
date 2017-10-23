using ProtienTrackerRedis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtienTrackerRedis.DAL.Abstract
{
	public interface IRepository<T> where T : BaseEntity
	{
		T Add(T t);
		T Update(T t);
		void Delete(T t);
		void DeleteByKey(long key);
		IEnumerable<T> GetAll();
		T Get(long id);
	}
}
