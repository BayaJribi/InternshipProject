using Dashboard_DW_V2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DWHouse_Dashboard.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<EmailDataChartBar> EmailChartBar { get; set; }
        public DbSet<PreferencesDataToPieChart> PreferencestoChartPie { get; set; }
        public DbSet<VisitChart> visitChart { get; set; }

    }

    public class AuthDBContext : IdentityDbContext<User>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {

        }

    }
}
