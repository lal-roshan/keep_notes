using System;

namespace KeepNotesDAO.Exceptions
{
    /// <summary>
    /// Exception to be thrown if ID already exists for an entity
    /// </summary>
    public class IDAlreadyExistsException: Exception
    {
        public IDAlreadyExistsException(string entity, string id):
            base(string.Format("A {0} with {0} ID: {1}, already exists", entity, id))
        {

        }
    }
}
