using AccomodationApi.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AccomodationApi.Data
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options)
        : base(options)
        {
        }
        public DbSet<Property> Property { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<PropertyInfo> PropertyInfo { get; set; }

        public DbSet<AvailableProperty> AvailableProperty { get; set; }

        //public IEnumerable<AvailableProperty> ExecuteAllPropertiesSp()
        //{
        //    var valProps = this.Set<AvailableProperty>().FromSqlRaw("EXEC [dbo].[getAllData]").ToList();
        //    return valProps;
        //}

        
    }
}
