using GenericConnectionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConnectionCore
{
    internal class ProcessData : Command, IReadData
    {
        public ICollection<T> ReadData<T>(IReadData dataReader, IEntitySetting entity)
        {
            throw new NotImplementedException();
        }
        public ICollection<T> ReadData<T>(IDataReader dataReader, IEntitySetting entity)
        {
            try
            {
                List<T> data = new List<T>();
                while (dataReader.Read())
                {
                    data.Add(entity.EntitySetting<T>(dataReader));
                }
                return data;
            }
            catch
            {
                throw new Exception("Error to read data");
            }
        }
        public virtual DataTable ReadData(IDataReader dataReader)
        {
            DataTable data = new DataTable();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                data.Columns.Add(new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i)));
            }
            while (dataReader.Read())
            {
                DataRow row = data.NewRow();
                foreach (DataColumn column in data.Columns)
                {
                    row[column] = dataReader[column.ColumnName];
                }
                data.Rows.Add(row);
            }
            return data;
        }
        public override IDataReader ExecuteCommand(string sql, IDbConnection connection)
        {
            try
            {
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
            }
            catch
            {
                throw new Exception("Error en la extracción de datos, verifique la conexión y que el sistema de consultas esté correctamente configurado.");
            }
        }
    }
}
