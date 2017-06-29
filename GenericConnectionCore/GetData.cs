using GenericConnectionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Logfile;

namespace GenericConnectionCore
{
    public class GetData
    {
        private readonly ProcessData processData;
        public virtual ICollection<T> Data<T>(string sql, IEntitySetting entity, IDbConnection connection)
        {
            WriteInDiskLogfile writeLog = new WriteInDiskLogfile();
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                writeLog.Log("Successful data extraction process");
                return new List<T>(processData.ReadData<T>(reader, entity));
            }
            catch (Exception ex)
            {
                WriteLog(writeLog, "Error in data extraction event", 12, ex.GetType(), "Method <Data>");
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
            WriteInDiskLogfile writeLog = new WriteInDiskLogfile();
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                writeLog.Log("Successful data return");
                return reader;
            }
            catch (Exception ex)
            {   
                WriteLog(writeLog, "Error while attempting to extract data", 33, ex.GetType(), "Method <GetDataReader>");
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
            WriteInDiskLogfile writeLog = new WriteInDiskLogfile();
            try
            {
                IDataReader reader = processData.ExecuteCommand(sql, connection);
                writeLog.Log("Successful data table return");
                return processData.ReadData(reader);
            }
            catch (Exception ex)
            {
                WriteLog(writeLog, "Error while attempting to extract data table", 53, ex.GetType(), "Method <GetTable>");
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
            WriteInDiskLogfile writeLog = new WriteInDiskLogfile();
            try
            {
                IDataReader reader = processData.ExecuteCommand(command);
                writeLog.Log("Successful data list return");
                return new List<T>(processData.ReadData<T>(reader, entity));
            }
            catch (Exception ex)
            {
                WriteLog(writeLog, "Error while attempting to extract data list", 73, ex.GetType(), "Method <Data>");
                throw new Exception(ex.Message);
            }
        }
        private void WriteLog(WriteInDiskLogfile writeLog, string message, int lineNum, Type errorType, string controlName)
        {
            try
            {
                Loginfo info = new Loginfo();
                info.ControlName = controlName;
                info.ErrorLineNum = lineNum;
                info.EventName = message;
                info.MainName = "GenericConnectionCore";
                info.ExceptionName = errorType.ToString();
                writeLog.Log(info);
            }
            catch (Exception ex)
            {
                writeLog.Log(string.Format("Error while attempting write in logfile.<-- {0} -->", ex.Message));
            }
        }
    }
}
