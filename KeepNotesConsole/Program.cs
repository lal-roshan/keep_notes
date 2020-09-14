using KeepNotesDAO;
using KeepNotesDAO.Helper;
using KeepNotesDAO.Models;
using KeepNotesDAO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static KeepNotesDAO.Helper.Common;

namespace KeepNotesConsole
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                ConsoleKeyInfo c;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Choose preffered operation number:\n");
                    Console.WriteLine("1.Create");
                    Console.WriteLine("2.Read");
                    Console.WriteLine("3.Update");
                    Console.WriteLine("4.Delete");
                    Console.WriteLine();

                    int oprtn = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (oprtn)
                    {
                        #region Create options
                        case 1:
                            Console.WriteLine("Choose preffered operation number:\n");
                            Console.WriteLine("1.Create new user");
                            Console.WriteLine("2.Create new category");
                            Console.WriteLine("3.Create new note");
                            Console.WriteLine();

                            int opt1 = Convert.ToInt32(Console.ReadLine());

                            switch (opt1)
                            {
                                case 1:
                                    CreateNewUser();
                                    break;
                                case 2:
                                    CreateNewCategory();
                                    break;
                                case 3:
                                    CreateNewNote();
                                    break;
                                default:
                                    Console.WriteLine("Invalid operation!!!\n");
                                    break;
                            }
                            break;
                        #endregion

                        #region Read options
                        case 2:
                            Console.WriteLine("Choose preffered operation number:\n");
                            Console.WriteLine("1.Read a user");
                            Console.WriteLine("2.Read all users");
                            Console.WriteLine("3.Read a category");
                            Console.WriteLine("4.Read all categories");
                            Console.WriteLine("5.Read a note");
                            Console.WriteLine("6.Read all notes");
                            Console.WriteLine();

                            int opt2 = Convert.ToInt32(Console.ReadLine());

                            switch (opt2)
                            {
                                case 1:
                                    ReadAUserDetail();
                                    break;
                                case 2:
                                    ReadAllUsers();
                                    break;
                                case 3:
                                    ReadCategoryProperties();
                                    break;
                                case 4:
                                    ReadAllCategories();
                                    break;
                                case 5:
                                    ReadANoteProperties();
                                    break;
                                case 6:
                                    ReadAllNotes();
                                    break;
                                default:
                                    Console.WriteLine("Invalid operation!!!\n");
                                    break;
                            }
                            break;
                        #endregion

                        #region Update options
                        case 3:
                            Console.WriteLine("Choose preffered operation number:\n");
                            Console.WriteLine("1.Update a user");
                            Console.WriteLine("2.Update a category");
                            Console.WriteLine("3.Update a note");
                            Console.WriteLine();

                            int opt3 = Convert.ToInt32(Console.ReadLine());

                            switch (opt3)
                            {
                                case 1:
                                    UpdateUser();
                                    break;
                                case 2:
                                    UpdateCategory();
                                    break;
                                case 3:
                                    UpdateNote();
                                    break;
                                default:
                                    Console.WriteLine("Invalid operation!!!\n");
                                    break;
                            }
                            break;
                        #endregion

                        #region Delete options
                        case 4:
                            Console.WriteLine("Choose preffered operation number:\n");
                            Console.WriteLine("1.Delete a user");
                            Console.WriteLine("2.Delete a category");
                            Console.WriteLine("3.Delete a note");
                            Console.WriteLine();

                            int opt4 = Convert.ToInt32(Console.ReadLine());

                            switch (opt4)
                            {
                                case 1:
                                    DeleteUser();
                                    break;
                                case 2:
                                    DeleteCategory();
                                    break;
                                case 3:
                                    DeleteNote();
                                    break;
                                default:
                                    Console.WriteLine("Invalid operation!!!\n");
                                    break;
                            }
                            break;
                            #endregion
                    }

                    Console.WriteLine("\n\nPress any key to try again(press esc to exit)");
                    c = Console.ReadKey();
                } while (c.Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                    Console.WriteLine(ex.InnerException?.Message);
                else
                    Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        #region Creation of entities
        /// <summary>
        /// Method to create new user
        /// </summary>
        private static void CreateNewUser()
        {
            User user = new User();
            Console.WriteLine("Enter new user details:\n");
            Console.Write("UserId: ");
            user.UserId = Console.ReadLine();
            Console.Write("UserName: ");
            user.UserName = Console.ReadLine();
            if (UserTableOperations.CreateNewUser(user))
            {
                Console.WriteLine("\n\n User creation successful");
            }
            else
            {
                Console.WriteLine("\n\n Some error occurred!!!");
            }
        }

        /// <summary>
        /// Method to create new category
        /// </summary>
        private static void CreateNewCategory()
        {
            Category category = new Category();
            Console.WriteLine("Enter new category details:\n");
            Console.Write("Description: ");
            category.Description = Console.ReadLine();
            Console.Write("UserId: ");
            category.UserId = Console.ReadLine();
            if (CategoryTableOperations.CreateNewCategory(category))
            {
                Console.WriteLine("\n\n Category creation successful");
            }
            else
            {
                Console.WriteLine("\n\n Some error occurred!!!");
            }
        }

        /// <summary>
        /// Method to creat note
        /// </summary>
        private static void CreateNewNote()
        {
            Note note = new Note();
            Console.WriteLine("Enter new note details:\n");
            Console.Write("Title: ");
            note.Title = Console.ReadLine();
            Console.Write("Description: ");
            note.Description = Console.ReadLine();
            Console.Write("CategoryId: ");
            note.CategoryId = Convert.ToInt32(Console.ReadLine());
            if (NotesTableOperations.CreateNote(note))
            {
                Console.WriteLine("\n\n Note creation successful");
            }
            else
            {
                Console.WriteLine("\n\n Some error occurred!!!");
            }
        }
        #endregion


        #region Reading of entities
        /// <summary>
        /// Method to read properties of a user
        /// </summary>
        /// <param name="userId">The Id of user whose properties are to be read</param>
        private static void ReadAUserDetail()
        {
            Console.WriteLine("\nEnter the UserId");
            string userId = Console.ReadLine();
            User user = UserTableOperations.ReadUserProperties(userId);
            if (user != null)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("UserName: " + user.UserName);
                Console.WriteLine("******************************");
            }
            else
            {
                Console.WriteLine("Some error occured!!!");
            }
        }

        /// <summary>
        /// Method to read all user details
        /// </summary>
        private static void ReadAllUsers()
        {
            List<User> users = UserTableOperations.ReadAllUsers();
            if (users.Any())
            {
                foreach (User user in users)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("UserId: " + user.UserId);
                    Console.WriteLine("UserName: " + user.UserName);
                    Console.WriteLine("******************************");
                }
            }
            else
            {
                Console.WriteLine("No Users found!!!");
            }
        }

        /// <summary>
        /// Method to read a categories properties
        /// </summary>
        private static void ReadCategoryProperties()
        {
            Console.WriteLine("\nEnter the CategoryId");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Category category = CategoryTableOperations.ReadACategoryAllProperties(categoryId);
            if (category != null)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Description: " + category.Description);
                Console.WriteLine("UserId: " + category.UserId);
                Console.WriteLine("******************************");
            }
            else
            {
                Console.WriteLine("Some error occurred!!!");
            }
        }

        /// <summary>
        /// Method to read all categories from table
        /// </summary>
        private static void ReadAllCategories()
        {
            List<Category> categories = CategoryTableOperations.ReadAllCategories();
            if (categories.Any())
            {
                foreach (Category category in categories)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("CategoryId: " + category.CategoryID);
                    Console.WriteLine("Description: " + category.Description);
                    Console.WriteLine("UserId: " + category.UserId);
                    Console.WriteLine("******************************");
                }
            }
            else
            {
                Console.WriteLine("No Categories found!!!");
            }
        }

        /// <summary>
        /// Method to read all properties of a note
        /// </summary>
        private static void ReadANoteProperties()
        {
            Console.WriteLine("\nEnter the note Id");
            int noteId = Convert.ToInt32(Console.ReadLine());
            Note note = NotesTableOperations.ReadANotesAllProperties(noteId);
            if (note != null)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Title: " + note.Title);
                Console.WriteLine("Description: " + note.Description);
                Console.WriteLine("Status: " + note.Status);
                Console.WriteLine("CategoryId: " + note.CategoryId);
                Console.WriteLine("******************************");
            }
            else
            {
                Console.WriteLine("Some error occurred!!!");
            }
        }

        /// <summary>
        /// Method to read all notes from table
        /// </summary>
        public static void ReadAllNotes()
        {
            List<Note> notes = NotesTableOperations.ReadAllNotes();
            if (notes.Any())
            {
                foreach (Note note in notes)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("NoteId: " + note.NoteId);
                    Console.WriteLine("Title: " + note.Title);
                    Console.WriteLine("Description: " + note.Description);
                    Console.WriteLine("Status: " + note.Status);
                    Console.WriteLine("CategoryId: " + note.CategoryId);
                    Console.WriteLine("******************************");
                }
            }
            else
            {
                Console.WriteLine("No notes found!!!");
            }
        }
        #endregion


        #region Updation of entities
        /// <summary>
        /// Method to update a user data
        /// </summary>
        public static void UpdateUser()
        {
            User user = new User();
            Console.WriteLine("\nEnter the Id of the user whose property is to be updated:");
            user.UserId = Console.ReadLine();
            Console.Write("Enter new username: ");
            user.UserName = Console.ReadLine();
            if (UserTableOperations.UpdateUser(user))
            {
                Console.WriteLine($"User '{user.UserId}' update successful");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }

        /// <summary>
        /// Method to update a category data
        /// </summary>
        public static void UpdateCategory()
        {
            Category category = new Category();
            Console.WriteLine("\nEnter the Id of the category that is to be updated");
            category.CategoryID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new description: ");
            category.Description = Console.ReadLine();
            Console.Write("Enter new Id of the user who created the category: ");
            category.UserId = Console.ReadLine();
            if (CategoryTableOperations.UpdateCategory(category, 0))
            {
                Console.WriteLine($"Category '{category.CategoryID}' update successful");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }

        /// <summary>
        /// Method to update a note
        /// </summary>
        public static void UpdateNote()
        {
            Note note = new Note();
            Console.WriteLine("\nEnter the id of the note that is to be updated:");
            note.NoteId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new titile: ");
            note.Title = Console.ReadLine();
            Console.Write("Enter new description: ");
            note.Description = Console.ReadLine();
            Console.Write("Select new status(1. Pending, 2. Completed, 3. Ignore)");
            int opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    note.Status = StatusType.Pending.ToString();
                    break;
                case 2:
                    note.Status = StatusType.Completed.ToString();
                    break;
                case 3:
                    note.Status = StatusType.Ignore.ToString();
                    break;
                default:
                    Console.WriteLine("Incorrect status. aborting!!!");
                    return;
            }
            Console.Write("Enter new category Id: ");
            note.CategoryId = Convert.ToInt32(Console.ReadLine());
            if (NotesTableOperations.UpdateNote(note, 0))
            {
                Console.WriteLine($"Note '{note.NoteId}' update successful");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }
        #endregion

        #region Deletion of entities
        /// <summary>
        /// Method to delete a user
        /// </summary>
        public static void DeleteUser()
        {
            Console.WriteLine("\nEnter the id of the user that you wish to delete:");
            string userID = Console.ReadLine();
            if (UserTableOperations.DeleteUser(userID))
            {
                Console.WriteLine($"The user '{userID}' was successfuly deleted");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }

        /// <summary>
        /// Method to delete a category
        /// </summary>
        public static void DeleteCategory()
        {
            Console.WriteLine("\nEnter the id of the category that you wish to delete:");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            if (CategoryTableOperations.DeleteCategory(categoryId))
            {
                Console.WriteLine($"The category '{categoryId}' was successfuly deleted");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }

        /// <summary>
        /// Method to delete a note
        /// </summary>
        public static void DeleteNote()
        {
            Console.WriteLine("\nEnter the id of the note that you wish to delete:");
            int noteId = Convert.ToInt32(Console.ReadLine());
            if (NotesTableOperations.DeleteNote(noteId))
            {
                Console.WriteLine($"The note '{noteId}' was successfuly deleted");
            }
            else
            {
                Console.WriteLine("Operation failed!!!");
            }
        }
        #endregion
    }
}