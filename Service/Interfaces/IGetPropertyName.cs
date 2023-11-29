using AccomodationApi.Model;

namespace AccomodationApi.Service.Interfaces
{
    public interface IGetPropertyName
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();

        Task<IEnumerable<UserInfo>> GetUserInfoAsync();

        Task<IEnumerable<PropertyInfo>> GetPropertyInfoAsync();

        Task<IEnumerable<AvailableProperty>> GetAvailableInfoAsync();
    }
}
