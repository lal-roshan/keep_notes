namespace KeepNotesDAO.Models
{
    /// <summary>
    /// Class representing user table
    /// </summary>
    public class User
    {
        /// <summary>
        /// The primary key user id column
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The user name column
        /// </summary>
        public string UserName { get; set; }
    }
}