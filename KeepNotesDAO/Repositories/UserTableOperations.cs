using KeepNotesDAO.Exceptions;
using KeepNotesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeepNotesDAO.Repositories
{
    /// <summary>
    /// Class containing methods for creating, deleting and updating users
    /// </summary>
    public class UserTableOperations
    {
        /// <summary>
        /// Method to read properties of a user
        /// </summary>
        /// <param name="userId">Id of the user whose properties is to be read</param>
        /// <returns>Return the user object</returns>
        public static User ReadUserProperties(string userId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var user = context.Users.Where(u => string.Equals(u.UserId, userId)).FirstOrDefault();
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        throw new IDNotFoundException("User", userId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to read all users from table
        /// </summary>
        /// <returns>List of users in table</returns>
        public static List<User> ReadAllUsers()
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    return context.Users?.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to create a new user
        /// </summary>
        /// <param name="newUser">The User object containing properties for new user</param>
        /// <returns>True if created successfully else false</returns>
        public static bool CreateNewUser(User newUser)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    if (context.Users.Any(user => string.Equals(user.UserId, newUser.UserId)))
                    {
                        throw new IDAlreadyExistsException("User", newUser.UserId);
                    }
                    else
                    {
                        context.Users.Add(newUser);
                        return context.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to delete a user
        /// </summary>
        /// <param name="userId">The details of User to be removed</param>
        /// <returns>Returns true if user details gets removed successfully</returns>
        public static bool DeleteUser(string userId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var user = context.Users.Where(u => string.Equals(u.UserId, userId)).FirstOrDefault();

                    if (user != null)
                    {
                        context.Users.Remove(user);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        throw new IDNotFoundException("User", userId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update details of an existing user
        /// </summary>
        /// <param name="updatedUser">Details of new user</param>
        /// <returns>TReturns true if updation was succesful else false</returns>
        public static bool UpdateUser(User updatedUser)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var oldUser = context.Users.Where(user => string.Equals(user.UserId, updatedUser.UserId))
                        .FirstOrDefault();
                    if (oldUser != null)
                    {
                        oldUser.UserName = updatedUser.UserName;
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        throw new IDNotFoundException("User", updatedUser.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
