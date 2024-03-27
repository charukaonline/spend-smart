using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace spend_smart
{
    public class dbConn
    {
        private static readonly Lazy<dbConn> instance = new Lazy<dbConn>(() => new dbConn());
        public static dbConn Instance => instance.Value;
        public string connString { get; private set; }

        public dbConn()
        {
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ssmart.accdb";
        }

        public bool TestConnection()
        {
            try
            {
                using (OleDbConnection dbConn = new OleDbConnection(connString))
                {
                    dbConn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
