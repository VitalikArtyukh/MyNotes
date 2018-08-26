
using Prism.Mvvm;
using SQLite;
using System;

namespace MyNotes.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Note
    /// </summary>
    [Table("Notes")]
    public class Note : BindableBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        public DateTime UpdateDate { get; set; }
    }
}
