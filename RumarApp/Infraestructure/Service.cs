using System.Security.Claims;
using Core.Security;
using DatabaseMigrations.Data;

namespace RumarApp.Infraestructure
{
    public class Service : IService
    {
        public ClaimsIdentity CurrentUser => ClaimsHelper.ClaimsIdentity;
        protected readonly ApplicationDbContext Database;

        public Service(ApplicationDbContext database)
        {
            Database = database;
        }
    }
}
