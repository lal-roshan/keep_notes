using KeepNotesDAO.Exceptions;
using KeepNotesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeepNotesDAO.Repositories
{
    /// <summary>
    /// Class containing methods to create, delete and update categories
    /// </summary>
    public class CategoryTableOperations
    {
        /// <summary>
        /// Method to read properties of a category
        /// </summary>
        /// <param name="categoryId">The ID of the category whose properties are to be read</param>
        /// <param name="property">The option number of the property</param>
        /// <returns>Returns the specfic property of mentioned category</returns>
        public static string ReadCategoryProperties(int categoryId, int property)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var category = context.Categories.Where(c => c.CategoryID == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        switch (property)
                        {
                            case 1:
                                return category.Description;
                            case 2:
                                return category.UserId;
                            default:
                                throw new InvalidOperationException("Invalid operation!!. Please choose a correct option");
                        }
                    }
                    else
                    {
                        throw new IDNotFoundException("Category", categoryId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to read all properties of a categories
        /// </summary>
        /// <param name="categoryId">The id of the category whose properties are to be read</param>
        /// <returns>Returns the category object corresponding to the id provided</returns>
        public static Category ReadACategoryAllProperties(int categoryId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var category = context.Categories.Where(c => c.CategoryID == categoryId).FirstOrDefault();
                    if(category != null)
                    {
                        return category;
                    }
                    else
                    {
                        throw new IDNotFoundException("Category", categoryId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to get all categories in the table
        /// </summary>
        /// <returns>Returns list of cateogry details</returns>
        public static List<Category> ReadAllCategories()
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    return context.Categories?.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to create a new Category
        /// </summary>
        /// <param name="newCategory">The Category object containing properties for new category</param>
        /// <returns>True if created successfully else false</returns>
        public static bool CreateNewCategory(Category newCategory)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    if (!context.Users.Any(user =>
                    string.Equals(user.UserId, newCategory.UserId)))
                    {
                        throw new IDNotFoundException("User", newCategory.UserId);
                    }
                    else if (context.Categories.Any(category =>
                     category.CategoryID == newCategory.CategoryID))
                    {
                        throw new IDAlreadyExistsException("Category", newCategory.CategoryID.ToString());
                    }
                    else
                    {
                        context.Categories.Add(newCategory);
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
        /// Method to delete a category
        /// </summary>
        /// <param name="categoryId">The id of category to be removed</param>
        /// <returns>Returns true if category details gets removed successfully</returns>
        public static bool DeleteCategory(int categoryId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var category = context.Categories.Where(c => c.CategoryID == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        context.Categories.Remove(category);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        throw new IDNotFoundException("Category", categoryId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update properties of a category
        /// </summary>
        /// <param name="updatedCategory">Category object with new details</param>
        /// <param name="property">The property that is to be updated</param>
        /// <returns>Returns true if value was updated else false</returns>
        public static bool UpdateCategory(Category updatedCategory, int property)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var oldCategory = context.Categories.Where(category => category.CategoryID == updatedCategory.CategoryID)
                        .FirstOrDefault();
                    if (oldCategory != null)
                    {
                        switch (property)
                        {
                            case 0:
                                oldCategory.Description = updatedCategory.Description;
                                if (!context.Users.Any(user =>
                                    string.Equals(user.UserId, updatedCategory.UserId)))
                                {
                                    throw new IDNotFoundException("User", updatedCategory.UserId);
                                }
                                else
                                {
                                    oldCategory.UserId = updatedCategory.UserId;
                                    return context.SaveChanges() > 0;
                                }
                            case 1:
                                oldCategory.Description = updatedCategory.Description;
                                return context.SaveChanges() > 0;
                            case 2:
                                if (!context.Users.Any(user =>
                                    string.Equals(user.UserId, updatedCategory.UserId)))
                                {
                                    throw new IDNotFoundException("User", updatedCategory.UserId);
                                }
                                else
                                {
                                    oldCategory.UserId = updatedCategory.UserId;
                                    return context.SaveChanges() > 0;
                                }
                            default:
                                throw new InvalidOperationException("Invalid operation!!. Please choose a correct option");
                        }
                    }
                    else
                    {
                        throw new IDNotFoundException("Category", updatedCategory.CategoryID.ToString());
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
