using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMSS.Areas.Identity.Data
{
    public class SeedDataApplicationRoles
    {
    public static async Task SeedAspNetRoles(RoleManager<IdentityRole> roleManager)
        {
             List<string> roleList = new List<string>()
            {
                "Basic",
               
                
            };

            foreach (var role in roleList)
            {
                var result = roleManager.RoleExistsAsync(role).Result;
                if (!result)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}