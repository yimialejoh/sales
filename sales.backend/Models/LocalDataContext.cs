

namespace sales.backend.Models
{
    using domain.Models;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<sales.common.Models.Product> Products { get; set; }
    }
}