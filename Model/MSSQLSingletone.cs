using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManage.Model
{
    class MSSQLSingletone
    {
        private static MSSQLSingletone _instance;
        private static SqlConnection con;


        private static string InstanceString;
        static MSSQLSingletone()
        {
        }

        private MSSQLSingletone()
        {
        }

        public static void InitInstanceString(string inst)
        {
            InstanceString = inst;
        }

        public static MSSQLSingletone GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MSSQLSingletone();
                con = new SqlConnection(InstanceString);
            }
            return _instance;
        }

        public SqlConnection GetDBConnection()
        {

            con = new SqlConnection(InstanceString);
            con.Open();
            return con;
        }

        public static bool TestConnection()
        {
            try
            {
                MSSQLSingletone.GetInstance().GetDBConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
