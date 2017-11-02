using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

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

        //Login subroutine
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = UserBox.Text;
            string password = PassBox.Password;
            string homeserver = HomeserverBox.Text;
            object1 = new trinity(homeserver=homeserver.ToString());
            statustext.Content = "Logging in, please wait";

            try
            {
                loginbutton.IsEnabled = false;
                Task<string> t = object1.Login(user, password);
                await t;
                Debug.WriteLine(t.Result);
                statustext.Content = "Login Success!";

                
                Window1 form = new Window1(object1.gettoken(), homeserver, object1.getadmin(), password);
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                loginbutton.IsEnabled = true;
                statustext.Content = "";
                Debug.WriteLine(ex);
            }
        }
    }
}
