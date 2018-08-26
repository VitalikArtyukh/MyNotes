using MyNotes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyNotes.Services
{
    /// <summary>
    /// NotesRepository
    /// </summary>
    /// <typeparam name="TNote">The type of the note.</typeparam>
    /// <seealso cref="MyNotes.Services.IRepository{TNote}" />
    internal class NotesRepository<TNote> : IRepository<TNote> where TNote : Note, new()
    {
        /// <summary>
        /// The database path
        /// </summary>
        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "notes.db3");

        /// <summary>
        /// The connection
        /// </summary>
        private readonly SQLiteConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository{TNote}"/> class.
        /// </summary>
        public NotesRepository()
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Note>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public TNote Create(TNote item)
        {
            _connection.Insert(item);
            return item;
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var rowCount = _connection.Delete<Note>(id);
            return Convert.ToBoolean(rowCount);
        }

        /// <inheritdoc />
        /// <summary> 
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public IEnumerable<TNote> GetAllItems()
        {
            return _connection.Query<TNote>("SELECT * FROM [Notes] ORDER By UpdateDate DESC");
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TNote GetItem(Guid id)
        {
            return _connection.Get<TNote>(id);
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public TNote Update(TNote item)
        {
            _connection.Update(item);
            return item;
        }
    }
}
