using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBManage.View
{
    /// <summary>
    /// Логика взаимодействия для InsertItemWindow.xaml
    /// </summary>
    public partial class InsertItemWindow : Window
    {

        private DataTable DataTable;
        private SqlDataAdapter Adapter;
        private List<TextBox> Text;
        private List<string> TextName;

        public InsertItemWindow(DataTable dt, SqlDataAdapter adapter)
        {
            InitializeComponent();
            this.Adapter = adapter;
            this.DataTable = dt;
            this.Text = new List<TextBox>();
            this.TextName = new List<string>();

            for (int i = 0; i < dt.Columns.Count; i++)
            {


                this.grid1.ColumnDefinitions.Add(new ColumnDefinition());
                Text.Add(new TextBox());

                string colName = dt.Columns[i].ColumnName; ;

                Text[i].Text = colName;
                TextName.Add(colName);
                Text[i].FontSize = 20;
                Text[i].FontWeight = FontWeights.Bold;
                Text[i].HorizontalAlignment = HorizontalAlignment.Center;
                //Grid.SetColumnSpan(txt1, 3);
                Grid.SetColumn(Text[i], i);
                this.grid1.Children.Add(Text[i]);

            }
            this.grid1.RowDefinitions.Add(new RowDefinition());

            Button butt = new Button();
            butt.Content = "Add";
            butt.Click += AddItem;
            Grid.SetColumn(butt, 1);
            Grid.SetColumnSpan(butt, this.Text.Count-2);
            Grid.SetRow(butt, 1);
            this.grid1.Children.Add(butt);


        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            DataRow newRow = this.DataTable.NewRow();
            for (int i = 0; i < Text.Count; i++)
            {
                newRow[TextName[i]] = Text[i].Text;
            }

            this.DataTable.Rows.Add(newRow);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.Adapter);
            this.Adapter.Update(this.DataTable);
        }
    }
}
