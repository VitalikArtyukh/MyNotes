using System;
using System.Collections.Generic;

namespace MyNotes.Services
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllItems();

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetItem(Guid id);

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        T Create(T item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        T Update(T item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool Delete(Guid id);
    }
}
