using MyNotes.Models;
using System;
using System.Collections.Generic;

namespace MyNotes.Services
{
    /// <summary>
    /// NotesManager
    /// </summary>
    /// <typeparam name="TNote">The type of the note.</typeparam>
    /// <seealso cref="MyNotes.Services.INotesManager{TNote}" />
    public class NotesManager<TNote> : INotesManager<TNote> where TNote : Note, new()
    {
        /// <summary>
        /// The notes repository
        /// </summary>
        private readonly IRepository<TNote> _notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager{TNote}"/> class.
        /// </summary>
        /// <param name="notesRepository">The versions repository.</param>
        public NotesManager(IRepository<TNote> notesRepository)
        {
            _notesRepository = notesRepository;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <returns></returns>
        public TNote CreateNote()
        {
            var note = new TNote()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Title = "Нова замітка",
                Text = "Замітка"
            };
            return _notesRepository.Create(note);
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public bool DeleteNote(TNote note)
        {
           return _notesRepository.Delete(note.Id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TNote> GetAllNotes()
        {
            return _notesRepository.GetAllItems();
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the note by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TNote GetNoteById(Guid id)
        {
            return _notesRepository.GetItem(id);
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        public TNote UpdateNote(TNote note)
        {
            note.UpdateDate = DateTime.Now;
            return _notesRepository.Update(note);
        }
    }
}
