#region Usings
using KeepNotesDAO;
using System;
#endregion

#region Namespace
namespace KeepNotesConsole
{
    #region Class
    class Program
    {
        #region Public methods
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            KeepNotesDBContext keepNotesDBContext = new KeepNotesDBContext();
            keepNotesDBContext.SaveChanges();
        } 
        #endregion
    } 
    #endregion
}

#endregion