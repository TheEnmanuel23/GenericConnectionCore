using System.Data;

namespace GenericConnectionCore.Interfaces
{
    public interface IEntitySetting
    {
        T EntitySetting<T>(IDataRecord dataRecord);
    }
}
