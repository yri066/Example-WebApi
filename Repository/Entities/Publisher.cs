using LinqToDB.Mapping;
using System;

namespace WebApi.Repository.Entities
{
	/// <summary>
	/// Издатель.
	/// </summary>
	[Table(Name = "Publisher")]
	public class Publisher
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public Guid Id { get; set; }

		/// <summary>
		/// Название издательства.
		/// </summary>
		[Column]
		public string Name { get; set; }
	}
}
