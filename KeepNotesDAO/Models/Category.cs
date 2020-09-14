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
        /// The foregin key for saving the user who created the category
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A property for letting category to know that UserId is key of User table
        /// </summary>
        public User User { get; set; }
    }
}