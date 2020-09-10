namespace KeepNotesDAO.Models
{
    /// <summary>
    /// Class representing Note table
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The primary key of the note table
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Title of the note
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the note
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Status of the note
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Foreign key representing the category under which the note comes
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// property to refer to Category table
        /// </summary>
        public Category Category { get; set; }
    }
}