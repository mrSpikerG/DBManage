using Dapper;
using DBManage.Model;
using DBManage.ViewModel;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Data.SqlClient;

namespace DBManage.View
{
    /// <summary>
    /// Логика взаимодействия для ConnectedWindow.xaml
    /// </summary>
    public partial class ConnectedWindow : Window
    {
        private readonly ConnectedViewModel ConnectedViewModel;
        private SqlDataAdapter DataAdapter;
        private DataTable DataTable;

        //Server = localhost\\SQLEXPRESS; Database = Resorces; Trusted_Connection = True;

        public ConnectedWindow()
        {
            InitializeComponent();
            this.ConnectedViewModel = new ConnectedViewModel();
            this.DataContext = this.ConnectedViewModel;



            using (IDbConnection conn = MSSQLSingletone.GetInstance().GetDBConnection())
            {
                conn.Query<string>("SELECT * FROM sys.Tables;").ToList().ForEach(item => this.listBox1.Items.Add(item));
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBox1.SelectedValue != null)
            {
                string Name = this.listBox1.SelectedValue.ToString();


                this.DataAdapter = new SqlDataAdapter($"SELECT * FROM {this.listBox1.SelectedValue}", MSSQLSingletone.GetInstance().GetDBConnection());
                this.DataTable = new DataTable();


                this.DataAdapter.Fill(this.DataTable);

                this.dataGrid.ItemsSource = this.DataTable.DefaultView;



            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.listBox1.SelectedValue != null)
            {
                InsertItemWindow insertItemWindow = new InsertItemWindow(this.DataTable,this.DataAdapter);
                insertItemWindow.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // :D
            /*  if (this.listBox1.SelectedValue != null)
              {
                  if (this.dataGrid.SelectedItem != null)
                  {
                      this.dataGrid.SelectedIndex
                      this.dt.AsEnumerable().Select(x => x.ItemArray).ToList().ForEach();
                  }
              }*/
        }
    }
}

