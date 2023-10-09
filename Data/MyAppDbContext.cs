using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDWithModalPopup.Models.DBEntities;

namespace CRUDWithModalPopup.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext (DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDWithModalPopup.Models.DBEntities.Product> Products { get; set; } = default!;
    }
}
