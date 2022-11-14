using DBManage.Model;
using DBManage.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBManage.ViewModel
{
    class MainViewModel
    {

        //{"ConnectionString":"Server = localhost\\SQLEXPRESS; Database = Resorces; Trusted_Connection = True;"}

        public string Database { get; set; }
        public string Server { get; set; }


        private ConnectedWindow connectedWindow;

        public void getValues()
        {
            if (this.Database == null)
                return;
            if (this.Server == null)
                return;

            string instance = $"Server = localhost\\{this.Server}; Database = {this.Database}; Trusted_Connection = True;";

            MSSQLSingletone.InitInstanceString(instance);

            if (MSSQLSingletone.TestConnection())
            {
                connectedWindow = new ConnectedWindow();
                connectedWindow.Show();
            }


        }
    }
}
