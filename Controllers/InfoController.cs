using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.Repository.Entities.ViewModels;
using System.Collections.Generic;

namespace WebApi.Controllers
{
	/// <summary>
	/// Выводит результаты запросов к бд.
	/// </summary>
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class InfoController : Controller
	{
		/// <summary>
		/// Реализует запросы к бд через Linq2db.
		/// </summary>
		private Linq2dbDataProvider _context { get; }

		/// <summary>
		/// Конструктор с параметрами
		/// </summary>
		/// <param name="context">Экземпляр класса для запросов к бд через Linq2db.</param>
		public InfoController(Linq2dbDataProvider context)
		{
			_context = context;
		}

		/// <summary>
		/// Сформировать список людей не вернувших книгу вовремя.
		/// </summary>
		/// <returns>Список людей с информацией о взятой книге.</returns>
		[HttpGet]
		public IEnumerable<IssueReaderViewModel> GetReaderNotReturnedBook()
		{
			return _context.GetReaderNotReturnedBook();
		}

		/// <summary>
		/// Сформировать список авторов и их книг.
		/// </summary>
		/// <returns>Список авторов и их книги.</returns>
		[HttpGet]
		public IEnumerable<AuthorsBooksViewModel> GetAuthorBooks()
		{
			return _context.GetAuthorBooks();
		}
	}
}
