using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudEmpCore.Model;

namespace CrudEmpCore.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<CrudEmpCore.Model.EmpRegistration> EmpRegistration { get; set; }
    }
}
