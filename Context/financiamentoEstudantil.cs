using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiEdubank.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace apiEdubank.Context;
public class apiEdubankContext : IdentityDbContext
{
    public apiEdubankContext(DbContextOptions options) : base(options) {}
    public DbSet<Financiamento>? Financiamentos {get; set;}
    public DbSet<Usuario>? Usuarios {get; set;}
}
