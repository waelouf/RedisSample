namespace ProtienTrackerRedis.Entities
{
	public class User : BaseEntity
    {
		public string Name { get; set; }

		public int Total { get; set; }

		public int Goal { get; set; }
	}
}
