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
        public static string userPhoneNum { get; set; }

        public static void StartSession(int userID, string username, string phoneNum)
        {
            CurrentUserID = userID;
            CurrentUsername = username;
            userPhoneNum = phoneNum;
        }

        public static void EndSession()
        {
            CurrentUserID = 0;
            CurrentUsername = null;
            userPhoneNum = null;
        }
    }

}
