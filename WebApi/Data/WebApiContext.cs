using Microsoft.EntityFrameworkCore;
using WebApi.Entity;

namespace WebApi.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) 
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }

   
}
