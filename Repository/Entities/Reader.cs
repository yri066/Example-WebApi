using LinqToDB.Mapping;

namespace WebApi.Repository.Entities
{
	/// <summary>
	/// Читатель.
	/// </summary>
	[Table(Name = "Reader")]
	public class Reader
	{

		/// <summary>
		/// Идентификатор.
		/// </summary>
		[PrimaryKey, Identity]
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Column]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Column]
		public string LastName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Column]
		public string Patronymic { get; set; }

		/// <summary>
		/// Адрес.
		/// </summary>
		[Column]
		public string Address { get; set; }

		/// <summary>
		/// Телефон.
		/// </summary>
		[Column]
		public string Phone { get; set; }
	}
}
