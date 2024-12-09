using Core.Kernel.DataAccess.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Core.Kernel.Helper;
using Core.Kernel.Dependency;

namespace RockPaperScissors.Model
{
    //public class RPSContextFactory : IDesignTimeDbContextFactory<RPSContext>, IDependencyInjection
    //{
    //    public RPSContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<RPSContext>();
    //        optionsBuilder.UseSqlServer("server=(local);database=RockPaperScissors;trusted_connection=true;"); // Ensure this matches your application's connection string

    //        return new RPSContext(optionsBuilder.Options, contextHelper, logger);
    //    }
    //}
}
