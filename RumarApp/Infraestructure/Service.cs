using Core.Security;
using DatabaseMigrations.Data;

namespace RumarApp.Infraestructure
{
    public class Service : IService
    {
        protected readonly ApplicationDbContext Database;

        public Service(ApplicationDbContext database)
        {
            Database = database;
        }
    }
}
