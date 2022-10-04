using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace WebApi.Controllers
{
	/// <summary>
	/// Работа с таблицей автор
	/// </summary>
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AuthorController : Controller
	{
		/// <summary>
		/// Реализует запросы к бд через Linq2db.
		/// </summary>
		private Linq2dbDataProvider _context { get; }

		/// <summary>
		/// Конструктор с параметрами
		/// </summary>
		/// <param name="context">Экземпляр класса для запросов к бд через Linq2db.</param>
		public AuthorController(Linq2dbDataProvider context)
		{
			_context = context;
		}

		/// <summary>
		/// Сформировать список всех авторов.
		/// </summary>
		/// <returns>Список всех авторов.</returns>
		[HttpGet]
		public IEnumerable<Author> GetAllAuthor()
		{
			return _context.GetAllAuthor();
		}

		/// <summary>
		/// Найти автора по id.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автор.</returns>
		[HttpGet]
		[Route("{id:guid}")]
		public Author FindAuthor(Guid id)
		{
			return _context.GetAuthor(id);
		}

		/// <summary>
		/// Добавление автора в бд.
		/// </summary>
		/// <param name="FirstName">Имя.</param>
		/// <param name="LastName">Фамиляи.</param>
		/// <param name="Patronymic">Отчество</param>
		/// <returns>Автор.</returns>
		[HttpPost]
		public Author AddAuthor(string FirstName, string LastName, string Patronymic)
		{
			return _context.AddAuthor(new Author
			{
				FirstName = FirstName,
				LastName = LastName,
				Patronymic = Patronymic
			});
		}

		/// <summary>
		/// Удаление автора по id.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Код ответа HTTP.</returns>
		[HttpDelete]
		public HttpStatusCode DeleteAuthor(Guid id)
		{
			_context.DeleteAuthor(id);
			return HttpStatusCode.OK;
		}
	}
}
