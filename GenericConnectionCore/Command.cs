using System;
using System.Data;

namespace GenericConnectionCore
{
    internal class Command
    {
        public virtual IDataReader ExecuteCommand(string sql, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public virtual IDataReader ExecuteCommand(IDbCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
