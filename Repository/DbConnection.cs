using LinqToDB;
using LinqToDB.Data;
using WebApi.Repository.Entities;
using System;

namespace WebApi.Repository
{
	/// <summary>
	/// Контекст подключения к базе для Linq2db.
	/// </summary>
	internal class DbConnection : DataConnection
	{
		/// <summary>
		/// Конструктор контекста подключения.
		/// </summary>
		public DbConnection() : base(ProviderName.SqlServer,
			string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\Library.mdf;
			Database=Library;Integrated Security=True;Connect Timeout=30", Environment.CurrentDirectory))
		{ }

		/// <summary>
		/// Автор.
		/// </summary>
		public ITable<Author> Author => this.GetTable<Author>();

		/// <summary>
		/// Книга.
		/// </summary>
		public ITable<Book> Book => this.GetTable<Book>();

		/// <summary>
		/// Издатель.
		/// </summary>
		public ITable<Publisher> Publisher => this.GetTable<Publisher>();

		/// <summary>
		/// Выдача.
		/// </summary>
		public ITable<Issue> Issue => this.GetTable<Issue>();

		/// <summary>
		/// Читатель.
		/// </summary>
		public ITable<Reader> Reader => this.GetTable<Reader>();
	}
}
