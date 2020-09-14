using KeepNotesDAO.Models;
using Microsoft.EntityFrameworkCore;
using static KeepNotesDAO.Helper.Common;

namespace KeepNotesDAO
{
    /// <summary>
    /// Class inheriting dbcontext and facilitating all the required functionalities
    /// </summary>
    public class KeepNotesDBContext : DbContext
    {
        #region Properties
        /// <summary>
        /// DB set property representing the users table
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// DB set property representing the categories table
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// DB set property representing the notes table
        /// </summary>
        public DbSet<Note> Notes { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public KeepNotesDBContext() : base()
        {

        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Method to perform task when the db is being configured
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress;database=KeepNotesDB;User=sa;Password=pass@123");
        }

        /// <summary>
        /// Method to set properties to models when they are being created
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
            modelBuilder.Entity<Category>().Property(c => c.Description).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.UserId).IsRequired();

            modelBuilder.Entity<Note>().HasKey(n => n.NoteId);
            modelBuilder.Entity<Note>().Property(n => n.Title).IsRequired();
            modelBuilder.Entity<Note>().Property(n => n.Status)
                .IsRequired().HasDefaultValue(StatusType.Pending.ToString());
            modelBuilder.Entity<Note>().Property(n => n.Description).IsRequired();
            modelBuilder.Entity<Note>().Property(n => n.CategoryId).IsRequired();
        }
        #endregion
    }
}
