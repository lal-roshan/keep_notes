using KeepNotesDAO.Exceptions;
using KeepNotesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeepNotesDAO.Repositories
{
    /// <summary>
    /// Class containing methods to read, create, delete and update notes
    /// </summary>
    public class NotesTableOperations
    {
        /// <summary>
        /// Method to read properties of a note
        /// </summary>
        /// <param name="noteId">The id of note to be read</param>
        /// <param name="property">The option number of property that is to be read</param>
        /// <returns>Returns the specific property</returns>
        public static string ReadNotesProperty(int noteId, int property)
        {
            try
            {
                using(KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var note = context.Notes.Where(n => n.NoteId == noteId).FirstOrDefault();
                    if(note != null)
                    {
                        switch (property)
                        {
                            case 1:
                                return note.Title;
                            case 2:
                                return note.Description;
                            case 3:
                                return note.Status;
                            case 4:
                                return note.CategoryId.ToString();
                            default:
                                throw new InvalidOperationException("Invalid operation!!. Please choose a correct option");
                        }
                    }
                    else
                    {
                        throw new IDNotFoundException("Note", noteId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to read all properties of a note
        /// </summary>
        /// <param name="noteId">the id of the note whose properties are to be read</param>
        /// <returns>Returns the note object corresponding to the note id</returns>
        public static Note ReadANotesAllProperties(int noteId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var note = context.Notes.Where(n => n.NoteId == noteId).FirstOrDefault();
                    if (note != null)
                    {
                        return note;
                    }
                    else
                    {
                        throw new IDNotFoundException("Note", noteId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to read all notes in the table
        /// </summary>
        /// <returns>Returns list of note objects</returns>
        public static List<Note> ReadAllNotes()
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    return context.Notes?.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to create a new note
        /// </summary>
        /// <param name="newNote">The note object containing properties for new note</param>
        /// <returns>Returns true if creation was successful else false</returns>
        public static bool CreateNote(Note newNote)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    if(context.Notes.Any(note => note.NoteId == newNote.NoteId))
                    {
                        throw new IDAlreadyExistsException("Note", newNote.NoteId.ToString());
                    }
                    else
                    {
                        context.Notes.Add(newNote);
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
        /// Method to delete a note
        /// </summary>
        /// <param name="noteId">The id of the note that is to be deleted</param>
        /// <returns>Returns true if deleted successfuly else false</returns>
        public static bool DeleteNote(int noteId)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var note = context.Notes.Where(n => n.NoteId == noteId).FirstOrDefault();
                    if (note != null)
                    {
                        context.Notes.Remove(note);
                        return context.SaveChanges() > 0;
                    }
                    else
                    {
                        throw new IDNotFoundException("Note", noteId.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update properties of a note
        /// </summary>
        /// <param name="updatedNote">The updated note object</param>
        /// <param name="property">The option number of property that is to be updated</param>
        /// <returns></returns>
        public static bool UpdateNote(Note updatedNote, int property)
        {
            try
            {
                using (KeepNotesDBContext context = new KeepNotesDBContext())
                {
                    var oldNote = context.Notes.Where(note => note.NoteId == updatedNote.NoteId).FirstOrDefault();
                    if(oldNote != null)
                    {
                        switch (property)
                        {
                            case 0:
                                oldNote.Title = updatedNote.Title;
                                oldNote.Description = updatedNote.Description;
                                oldNote.Status = updatedNote.Status;
                                oldNote.CategoryId = updatedNote.CategoryId;
                                return context.SaveChanges() > 0;
                            case 1:
                                oldNote.Title = updatedNote.Title;
                                return context.SaveChanges() > 0;
                            case 2:
                                oldNote.Description = updatedNote.Description;
                                return context.SaveChanges() > 0;
                            case 3:
                                oldNote.Status = updatedNote.Status;
                                return context.SaveChanges() > 0;
                            case 4:
                                oldNote.CategoryId = updatedNote.CategoryId;
                                return context.SaveChanges() > 0;
                            default:
                                throw new InvalidOperationException("Invalid operation!!. Please choose a correct option");
                        }
                    }
                    else
                    {
                        throw new IDNotFoundException("Note", updatedNote.NoteId.ToString());
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
