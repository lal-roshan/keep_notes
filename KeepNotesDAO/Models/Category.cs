namespace KeepNotesDAO.Models
{
    /// <summary>
    /// Class representing Category table
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The primary key column of category table
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The foreign key representing the user who created the category
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// A property to refer to the User table
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Property to refer to the Note table
        /// </summary>
        public Note Note { get; set; }
    }
}