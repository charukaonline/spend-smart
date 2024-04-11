using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spend_smart
{
    public class UserSession
    {
        public static int CurrentUserID { get; private set; }
        public static string CurrentUsername { get; private set; }

        public static void StartSession(int userID, string username)
        {
            CurrentUserID = userID;
            CurrentUsername = username;
        }

        public static void EndSession()
        {
            CurrentUserID = 0;
            CurrentUsername = null;
        }
    }

}
