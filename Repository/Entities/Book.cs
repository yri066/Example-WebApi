using LinqToDB.Mapping;
using System;

namespace WebApi.Repository.Entities
{
	/// <summary>
	/// Книга.
	/// </summary>
	[Table(Name = "Book")]
	public class Book
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Название книги.
		/// </summary>
		[Column]
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор автора.
		/// </summary>
		[Column]
		public Guid AuthorId { get; set; }

		/// <summary>
		/// Идентификатор издателя.
		/// </summary>
		[Column]
		public Guid PublisherId { get; set; }

		/// <summary>
		/// Год издания.
		/// </summary>
		[Column]
		public int PublicationYear { get; set; }
	}
}
