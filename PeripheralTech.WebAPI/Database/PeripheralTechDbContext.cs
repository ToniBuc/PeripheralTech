using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class PeripheralTechDbContext : DbContext
    {
        public PeripheralTechDbContext()
        {

        }
        public PeripheralTechDbContext(DbContextOptions<PeripheralTechDbContext> options) : base(options)
        {

        }
    }
}
