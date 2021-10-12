using Microsoft.EntityFrameworkCore.Storage;
using RumarApp.Data;
using RumarApp.Models;

namespace RumarApp.Infraestructure
{
    public class Service : IService
    {
        protected readonly ApplicationDbContext Database;

        public Service(ApplicationDbContext _Database)
        {
            Database = _Database;
        }

    }
}
