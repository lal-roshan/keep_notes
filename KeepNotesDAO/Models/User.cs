#region Namespace
namespace KeepNotesDAO.Models
{
    #region Class
    /// <summary>
    /// Class representing user table
    /// </summary>
    public class User
    {
        /// <summary>
        /// The primary key user id column
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// The user name column
        /// </summary>
        public string UserName { get; set; }

        public Category Category { get; set; }
    } 
    #endregion
}

#endregion