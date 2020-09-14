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
        /// The foreign key to identify the category of the note
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// property to refer to let note table to know that foreign key categoryID is from table category
        /// </summary>
        public Category Category { get; set; }
    }
}