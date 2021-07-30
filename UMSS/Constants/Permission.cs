using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMSS.Constants
{
    public class Permission
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
        }

        public static class Application
        {
            public const string View = "Permissions.Application.View";
            public const string Create = "Permissions.Application.Create";
            public const string Edit = "Permissions.Application.Edit";
            public const string Delete = "Permissions.Application.Delete";
        }
    }
}
