using System.Data;
using System.Collections.Generic;

namespace GenericConnectionCore.Interfaces
{
    public interface IReadData
    {
        ICollection<T> ReadData<T>(IDataReader dataReader, IEntitySetting entity);
    }
}
