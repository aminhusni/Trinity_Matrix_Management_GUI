using System;
using System.Collections.Generic;
using System.Diagnostics;
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



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        trinity object1;

        //Login button
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = UserBox.Text;
            string password = PassBox.Password;
            string homeserver = HomeserverBox.Text;

            object1 = new trinity(homeserver=homeserver.ToString());
            statustext.Content = "Logging in, please wait";

            try
            {
                Task<string> t = object1.Login(user, password);
                await t;
                Debug.WriteLine(t.Result);
                statustext.Content = "Login Success!";

                Window1 form = new Window1(object1.gettoken(), homeserver, object1.getadmin());
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                statustext.Content = ex;
            }
        }

    }
}
