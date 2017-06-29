using GenericConnectionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
