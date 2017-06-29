using System.Collections.Generic;

namespace GenericConnectionCore.Interfaces
{
    public interface IReadData
    {
        ICollection<T> ReadData<T>(IReadData dataReader, IEntitySetting entity);
    }
}
