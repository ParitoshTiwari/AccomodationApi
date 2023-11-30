using AccomodationApi.Model;
using AccomodationApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccomodationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly IGetPropertyName _getPropertyName;

        public PropertyController(IGetPropertyName propertyContext)
        {
            _getPropertyName = propertyContext;
        }

        [HttpGet("GetAllProperties")]
        public async Task<IEnumerable<Property>> GetPropertyInfo()
        {
            return await _getPropertyName.GetPropertiesAsync();
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<UserInfo>> GetAllUsers()
        {
            return await _getPropertyName.GetUserInfoAsync();
        }

        [HttpGet("GetAllAvailableProperties")]
        public async Task<IEnumerable<PropertyInfo>> GetAllAvailableProperties()
        {
            return await _getPropertyName.GetPropertyInfoAsync();
        }

        [HttpGet("ShowAllPropertiesData")]
        public async Task<IEnumerable<AvailableProperty>> ShowAllPropertiesData() 
        {
            return await _getPropertyName.GetAvailableInfoAsync();
        }
    }
}
