using AccomodationApi.Data;
using AccomodationApi.Model;
using AccomodationApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccomodationApi.Service.Services
{
    public class GetPropertyNameService : IGetPropertyName
    {
        private readonly PropertyContext _propertyContext;
        public GetPropertyNameService(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }
        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await _propertyContext.Property.ToListAsync();
        }

        public async Task<IEnumerable<PropertyInfo>> GetPropertyInfoAsync()
        {
            return await _propertyContext.PropertyInfo.ToListAsync();
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfoAsync() 
        {
            return await _propertyContext.UserInfo.ToListAsync();
        }

        public async Task<IEnumerable<AvailableProperty>> GetAvailableInfoAsync()
        {
            var propertyData = await _propertyContext.PropertyInfo.ToListAsync();
            var userData = await _propertyContext.UserInfo.ToListAsync();
            var propertyInfo = await _propertyContext.Property.ToListAsync();
            var combinedInfo = from property in propertyData
                               join user in userData on property.UserId equals user.Id
                               join singleProp in propertyInfo on property.PropertyId equals singleProp.PropertyId
                               select new AvailableProperty
                               {
                                   UserId = user.Id,
                                   BusStopDuration = property.BusStopDuration,
                                   Dishwasher = property.Dishwasher,
                                   Dryer = property.Dryer,
                                   Garrage = property.Garrage,
                                   Microwave = property.Microwave,
                                   Name = user.Name,
                                   Oven = property.Oven,
                                   Phone = user.Phone,
                                   PropertyAddress = singleProp.PropertyAddress,
                                   PropertyId = singleProp.PropertyId,
                                   PropertyName = singleProp.PropertyName,
                                   Refrigerator = property.Refrigerator,
                                   Washer = property.Washer
                               };
            return combinedInfo;
        }
    }
}
