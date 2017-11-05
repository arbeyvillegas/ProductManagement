using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.DB.Contexts
{
    public interface IContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        int Complete();
    }
}
