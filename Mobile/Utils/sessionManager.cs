using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Utils
{
    public static class sessionManager
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static int UserId { get; set; }
        public static string Role { get; set; }

        public static void Logout()
        {
            UserId = 0;
            Role = null;
        }

    }
}
