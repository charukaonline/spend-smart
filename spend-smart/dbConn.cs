using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace spend_smart
{
    internal class dbConn
    {
        private static readonly Lazy<dbConn> instance = new Lazy<dbConn>(() => new dbConn());
        public static dbConn Instance => instance.Value;
        public string connString { get; private set; }

        private dbConn()
        {
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ssmart.accdb";
        }
    }
}
