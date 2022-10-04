using LinqToDB;
using WebApi.Repository.Entities;
using WebApi.Repository.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Repository
{
	/// <summary>
	/// Реализует запросы через Linq2db.
	/// </summary>
	public class Linq2dbDataProvider
	{
		/// <summary>
		/// Сформировать список всех авторов.
		/// </summary>
		/// <returns>Список авторов.</returns>
		public IEnumerable<Author> GetAllAuthor()
		{
			using (var context = new DbConnection())
			{
				return context.Author.Take(1000).ToList();
			}
		}

		/// <summary>
		/// Найти автора по id.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автор.</returns>
		public Author GetAuthor(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}

			using (var context = new DbConnection())
			{
				return context.Author.SingleOrDefault(x => x.Id == id);
			}
		}

		/// <summary>
		/// Добавление автора в бд.
		/// </summary>
		/// <param name="author">Автор.</param>
		public Author AddAuthor(Author author)
		{
			if (author == null)
			{
				throw new ArgumentNullException(nameof(author));
			}

			using (var context = new DbConnection())
			{
				var id = Guid.NewGuid();
				context.Author
					.Value(x => x.Id, id)
					.Value(x => x.FirstName, author.FirstName)
					.Value(x => x.LastName, author.LastName)
					.Value(x => x.Patronymic, author.Patronymic)
					.Insert();

				return new Author
				{
					Id = id,
					FirstName = author.FirstName,
					LastName = author.LastName,
					Patronymic = author.Patronymic
				};
			}
		}

		/// <summary>
		/// Удалить автора по id.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автор.</returns>
		public void DeleteAuthor(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}

			using (var context = new DbConnection())
			{
				context.Author.Delete(x => x.Id == id);
			}
		}

		/// <summary>
		/// Сформировать список людей не вернувших книгу вовремя.
		/// </summary>
		/// <returns>Список людей с информацией о взятой книге.</returns>
		public IEnumerable<IssueReaderViewModel> GetReaderNotReturnedBook()
		{
			using (var context = new DbConnection())
			{
				return (from reader in context.Reader
							join issue in context.Issue
								on reader.Id equals issue.ReaderId
							join book in context.Book
								on issue.BookId equals book.Id
						where issue.ReturnDate < DateTime.Now
						where issue.Returned.Equals(0)
						select new IssueReaderViewModel
						{
							FirstName = reader.FirstName,
							LastName = reader.LastName,
							Patronymic = reader.Patronymic,
							Address = reader.Address,
							BookName = book.Name,
							ReturnDate = issue.ReturnDate
						})
						.Take(1000)
						.ToList();
			}
		}

		/// <summary>
		/// Сформировать список авторов и их книг.
		/// </summary>
		/// <returns>Список авторов и их книги.</returns>
		public IEnumerable<AuthorsBooksViewModel> GetAuthorBooks()
		{
			using (var context = new DbConnection())
			{
				return (from author in context.Author
							join book in context.Book
								on author.Id equals book.AuthorId
							join publisher in context.Publisher
								on book.PublisherId equals publisher.Id
						select new AuthorsBooksViewModel
						{
							FirstName = author.FirstName,
							LastName = author.LastName,
							Patronymic = author.Patronymic,
							BookName = book.Name,
							PublisherName = publisher.Name,
							PublicationYear = book.PublicationYear
						})
						.Take(1000)
						.ToList();
			}
		}
	}
}
