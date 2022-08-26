using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_DW_V2.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _RoleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _RoleManager = roleManager;
        }
    }
}
