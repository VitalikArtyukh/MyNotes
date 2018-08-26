using MyNotes.Models;
using System;
using System.Collections.Generic;

namespace MyNotes.Services
{
    /// <summary>
    /// IVersionManager
    /// </summary>
    /// <typeparam name="TNote">The type of the note.</typeparam>
    public interface INotesManager<TNote> where TNote : Note
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TNote> GetAllNotes();

        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <returns></returns>
        TNote CreateNote();

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        TNote UpdateNote(TNote note);

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        bool DeleteNote(TNote note);

        /// <summary>
        /// Gets the note by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TNote GetNoteById(Guid id);
    }
}
