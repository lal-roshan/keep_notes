using System;

namespace KeepNotesDAO.Exceptions
{
    /// <summary>
    /// Exception to be thrown if ID not found for an enitity
    /// </summary>
    public class IDNotFoundException : Exception
    {
        public IDNotFoundException(string entity, string id):
            base(string.Format("A {0} with {0} ID: {1} could not be found", entity, id))
        { }
    }
}
