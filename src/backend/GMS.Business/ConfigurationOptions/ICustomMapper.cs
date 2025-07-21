using GMS.Models.Security;

namespace GMS.Business.ConfigurationOptions;

public interface ICustomMapper
{
    object Map<T>(User user);
}