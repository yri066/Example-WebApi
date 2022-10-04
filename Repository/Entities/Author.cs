using LinqToDB.Mapping;
using System;

namespace WebApi.Repository.Entities
{
	/// <summary>
	/// Автор.
	/// </summary>
	[Table(Name = "Author")]
	public class Author
	{
		/// <summary>
		/// Идентификатор автора.
		/// </summary>
		[PrimaryKey, Identity]
		public Guid Id { get; set; }

		/// <summary>
		/// Имя автора.
		/// </summary>
		[Column]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия автора.
		/// </summary>
		[Column]
		public string LastName { get; set; }

		/// <summary>
		/// Отчество автора.
		/// </summary>
		[Column]
		public string Patronymic { get; set; }
	}
}
