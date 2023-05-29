using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GazStation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomDBConnection myConnect = new CustomDBConnection();
        public MainWindow()
        {
            InitializeComponent();
            myConnect.ConnectionString = @"Data Source=DESKTOP-CSA0P33\SQLEXPRESS;Initial Catalog=Gaz_Station;Integrated Security=True";
        }

        private void btn_auth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myConnect.Query = "select * from Users";
                myConnect.Open();
                myConnect.Execute();
                while (myConnect.Read())
                {
                    if (Convert.ToInt32(myConnect.Reader[5]) == 1)
                    {
                        MessageBox.Show("Admin");
                    }
                    else
                    {
                        MessageBox.Show("User");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                myConnect.Close();
            }
        }
    }
}
