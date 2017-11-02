using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        trinity object1;
        string TOKEN;
        string HOMESERVER;
        public static string[,] room;

        public Window1(string token, string homeserver, string adminuser, string password)
        {
            InitializeComponent();
            TOKEN = token;
            HOMESERVER = homeserver;
            object1 = new trinity(HOMESERVER, TOKEN, adminuser, password);
            getver();
        }
        //Get the version when init
        private async void getver()
        {
            string finalres =null;
            string value;

            try
            {
                Task<dynamic> t = object1.version();
                await t;

                foreach (string x in t.Result.versions)
                {
                    value = x;
                    Debug.WriteLine(value);
                    finalres = finalres + "Version " + value + "\n";
                }

                Debug.WriteLine(finalres);
                versionbox.Text = finalres;
            }
            catch (Exception ex)
            {
                versionbox.Text = "Error fetching supported version!";
                Debug.WriteLine(ex);

            }
        }
        //Userinfo button
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = usernamebox.Text;
            statusbox2.Document.Blocks.Clear();
            statusbox2.AppendText("Querying data, please wait...");

            try
            {
                Task<dynamic> t = object1.Whois(usernamebox.Text);
                await t;
                statusbox2.Document.Blocks.Clear();
                string username = t.Result.user_id;
                Debug.WriteLine(username);
                statusbox2.AppendText("User ID: " + t.Result.user_id + "\n\n");

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(t.Result.devices))
                {
                  string name = descriptor.Name;
                  object value = descriptor.GetValue(t.Result.devices);
                  statusbox2.AppendText(name+" : "+value+"\n");
                 }
            }
            catch (Exception ex)
            {
                statusbox2.AppendText("Something went wrong...\n");
                statusbox2.AppendText("ex");
                Debug.WriteLine(ex);
            }
        }
        //Allegedly when closing window
        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Debug.WriteLine("CLOSINGGGG");
            try
            {
                Debug.WriteLine("Logging out");
                Task<string> t = object1.Logout();
                await t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("logoutfail");
                Debug.WriteLine(ex);
            }
            Application.Current.Shutdown();
        }
        //Deactivate button
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string user = usernamebox.Text;
            statusbox2.Document.Blocks.Clear();

            try
            {
                Task<string> t = object1.deactivate(usernamebox.Text);
                await t;

                statusbox2.AppendText("User sucessfully deactivated\n");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        //Reset password
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string user = usernamebox.Text;
            statusbox2.Document.Blocks.Clear();

            try
            {
                Task<dynamic> t = object1.reset(usernamebox.Text);
                await t;
                statusbox2.AppendText("Password set!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        //Create new user
        private async void create_click(object sender, RoutedEventArgs e)
        {
            string user = username_create.Text;
            string pass = password_create.Password;
            string sec = secret_create.Password;
            bool? admin = admin_check.IsChecked;

            Debug.WriteLine(user);
            Debug.WriteLine(pass);
            Debug.WriteLine(sec);
            Debug.WriteLine(admin);

            statusbox2.Document.Blocks.Clear();

            try
            {
                Task<string> t = object1.create(user, pass, admin, sec);
                await t;
                statusboxcreate.Content = "User created!";
                username_create.Text = "";
                password_create.Password = "";
                secret_create.Password = "";
            }
            catch (Exception ex)
            {
                statusboxcreate.Content = "Something went wrong...";
                Debug.WriteLine(ex);
            }
        }
        //Query Rooms
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            roomlist.Items.Clear();
            int size = 0;
            int count = 0;

            try
            {
                Task<dynamic> t = object1.publicroom();
                await t;

                foreach (dynamic x in t.Result.chunk)
                {
                    size++;
                }

                Debug.WriteLine(size);
                Window1.room = new string[size, 2];
                count = 0;

                foreach (dynamic x in t.Result.chunk)
                {
                    try
                    {
                        room[count, 0] = t.Result.chunk[count].aliases[0];
                    }
                    catch
                    {
                        room[count, 0] = t.Result.chunk[count].name;
                    }

                    room[count, 1] = t.Result.chunk[count].room_id;
                    roomlist.Items.Add(room[count, 0]);
                    count++;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        //When a room was selected
        private void roomlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selection = 0;
            selection = roomlist.SelectedIndex;
            try
            {
                roomidbox.Text = Window1.room[selection, 1];
            }
            catch
            {
                roomidbox.Text = "";
            }
        }
        //Purge room
        private async void Purge_Button(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Purging a room will kick out all users including you and will never be accessible again.", "PURGE ROOM?", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    Task<dynamic> t = object1.purge(roomidbox.Text);
                    await t;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
