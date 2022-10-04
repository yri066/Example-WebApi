namespace WebApi.Repository.Entities.ViewModels
{
	/// <summary>
	/// Информация о авторе и его книгах.
	/// </summary>
	public class AuthorsBooksViewModel
	{
		/// <summary>
		/// Имя автора.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия автора.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Отчество автора.
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Название книги.
		/// </summary>
		public string BookName { get; set; }

		/// <summary>
		/// Название издательства.
		/// </summary>
		public string PublisherName { get; set; }

		/// <summary>
		/// Год издания.
		/// </summary>
		public int PublicationYear { get; set; }
	}
}
