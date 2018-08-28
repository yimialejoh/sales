
namespace sales.domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<sales.common.Models.Product> Products { get; set; }
    }
}
