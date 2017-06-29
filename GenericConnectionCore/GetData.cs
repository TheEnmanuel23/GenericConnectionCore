using GenericConnectionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConnectionCore
{
    public class GetData
    {
        private readonly ProcessData processData;
        public virtual ICollection<T> Data<T>(string sql, IEntitySetting entity, IDbConnection connection)
        {
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                return new List<T>(processData.ReadData<T>(reader, entity));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }
        public virtual IDataReader GetDataReader(string sql, IDbConnection connection)
        {
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public virtual DataTable GetTable(string sql, IDbConnection connection)
        {
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                return processData.ReadData(reader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public ICollection<T> Data<T>(IDbCommand command, IEntitySetting entity)
        {
            try
            {
                IDataReader reader = processData.ExecuteCommand(command);
                return new List<T>(processData.ReadData<T>(reader, entity));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
