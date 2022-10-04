using LinqToDB.Mapping;
using System;

namespace WebApi.Repository.Entities
{
	/// <summary>
	/// Выдача.
	/// </summary>
	[Table(Name = "Issue")]
	public class Issue
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		[Column]
		public int BookId { get; set; }

		/// <summary>
		/// Идентификатор читателя.
		/// </summary>
		[Column]
		public int ReaderId { get; set; }

		/// <summary>
		/// Дата выдачи.
		/// </summary>
		[Column]
		public DateTime IssueDate { get; set; }

		/// <summary>
		/// Дата возврата.
		/// </summary>
		[Column]
		public DateTime ReturnDate { get; set; }

		/// <summary>
		/// true - книга возвращена, false - книгу у читателя.
		/// </summary>
		[Column]
		public bool Returned { get; set; }
	}
}
