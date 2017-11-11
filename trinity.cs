using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net;
using System.Web.Security;

//System.Windows.MessageBox.Show("", "ERROR!", System.Windows.MessageBoxButton.OK);

namespace WpfApp1
{
    class trinity
    {

        string authstring;
        string BASE_URL;
        string auth_token;
        static Dictionary<string, string> auth_query = new Dictionary<string, string> { { "access_token", null } };
        string adminuser;
        string password;

        private static HttpClient client = new HttpClient();

        public trinity(string homeserver, string token = null, string adminuserr = null, string pass = null) { 
            BASE_URL = homeserver;
            auth_query["access_token"] = token;
            adminuser = adminuserr;
            password = pass;
            authstring = "?access_token=" + auth_query["access_token"];
            Debug.WriteLine(adminuserr);
        }

        public void checkresp(HttpStatusCode response)
        {
            if (response == HttpStatusCode.Forbidden)
            {
                System.Windows.MessageBox.Show("Authorization error", "ERROR!", System.Windows.MessageBoxButton.OK);
                throw new System.ArgumentException("Error 403");
            }

            if (response == HttpStatusCode.NotFound)
            {
                System.Windows.MessageBox.Show("Probably not a Matrix API or server is down", "ERROR!", System.Windows.MessageBoxButton.OK);
                throw new System.ArgumentException("Error 404");
            }

            if (response == HttpStatusCode.BadRequest)
            {
                System.Windows.MessageBox.Show("Request could not be fulfiled. Probably conflicting entry or invalid.", "ERROR!", System.Windows.MessageBoxButton.OK);
                throw new System.ArgumentException("Error 400");
            }

            if (response == HttpStatusCode.GatewayTimeout  || response == HttpStatusCode.BadGateway) {
                System.Windows.MessageBox.Show("Error contacting server", "ERROR!", System.Windows.MessageBoxButton.OK);
                throw new System.ArgumentException("Error 500 range");
            }

        }

        //LOGIN
        public async Task<string> Login(string user, string pass) {
            string json = "{\"type\":\"m.login.password\", \"user\":\"" + user + "\", \"password\":\"" + pass + "\"}";
            Debug.WriteLine(json);
            var response = await client.PostAsync(BASE_URL + "/_matrix/client/r0/login", new StringContent(json, Encoding.UTF8, "application/json"));
            var mes = await response.Content.ReadAsStringAsync();

            checkresp(response.StatusCode);

            Debug.WriteLine(mes);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(mes);
            auth_token = values["access_token"];
            adminuser = values["user_id"];

            return mes;
        }

        //Transition 
        public string gettoken() {
            return auth_token;
        }

        public string getadmin()
        {
            return adminuser;
        }
        //Whois User
        public async Task<dynamic> Whois(string user) {
            string GETINFO = "/_matrix/client/r0/admin/whois/";
            string query = BASE_URL + GETINFO + user;
            string fullquery = query + authstring;

            var response = await client.GetAsync(fullquery);
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            string modifiedmes = mes.Replace("\"\"", "\"unknown\"");
            Debug.WriteLine(modifiedmes);
            dynamic values = JsonConvert.DeserializeObject<dynamic>(modifiedmes);
            return values;
        }

        //Logout current session
        public async Task<string> Logout() {
            string logout = "/_matrix/client/r0/logout";
            string fullquery = BASE_URL + logout + authstring;
            var response = await client.GetAsync(fullquery);
            checkresp(response.StatusCode);


            return null;
        }

        //Deactivate an account
        public async Task<string> deactivate(string user) {
            string deactivate = "/_matrix/client/r0/admin/deactivate/";
            string query = BASE_URL + deactivate + user + authstring;

            Debug.WriteLine(query);
            var response = await client.PostAsync(query, null);
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            Debug.WriteLine(mes);

            return null;
        }

        public async Task<string> reset(string user) {

            string pass = Membership.GeneratePassword(10, 4);
            string reset = "/_matrix/client/r0/admin/reset_password/";
            string query = BASE_URL + reset + user + authstring;
            string json = "{\"new_password\":\""+  pass + "\"}";

            Debug.WriteLine(query);
            var response = await client.PostAsync(query, new StringContent(json, Encoding.UTF8, "application/json"));
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            Debug.WriteLine(mes);

            return pass;
        }

        //To be used by HMAC stuff
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }

        //Create new user using HMAC and the v1 API. 
        public async Task<string> create(string user, string password, bool? admin, string sharedsec) {

            string adminstat;
            string jsonbol;
            byte[] sharedsecbyte = Encoding.ASCII.GetBytes(sharedsec);
            HMACSHA1 mac1 = new HMACSHA1(sharedsecbyte);
            byte[] databyte;

            if (admin == true) { adminstat = "admin"; jsonbol = "true"; } else { adminstat = "notadmin"; jsonbol = "false"; }
            string premac = user+"\x00"+ password+"\x00"+adminstat;
            databyte = Encoding.ASCII.GetBytes(premac);
            byte[] calcHash = mac1.ComputeHash(databyte);
            string calcstring = ByteToString(calcHash);
            calcstring = calcstring.ToLower();
            Debug.WriteLine(calcstring);

            string create = "/_matrix/client/api/v1/register";
            string query = BASE_URL + create;
            Debug.WriteLine(query);
            string json = "{\"user\": \"" + user +"\", \"password\": \""+password+"\", \"mac\":\""+calcstring+"\", \"type\": \"org.matrix.login.shared_secret\", \"admin\": "+ jsonbol +"}";
            Debug.WriteLine(json);

            var response = await client.PostAsync(query, new StringContent(json, Encoding.UTF8, "application/json"));
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            Debug.WriteLine(mes);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(mes);
            return mes;
        }

        public async Task<dynamic> version()
        {
            string version = "/_matrix/client/versions";
            string query = BASE_URL + version + authstring;
            
            Debug.WriteLine(query);
            var response = await client.GetAsync(query);
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            Debug.WriteLine(mes);

            dynamic values = JsonConvert.DeserializeObject<dynamic>(mes);
            return values;
        }

        public async Task<dynamic> publicroom()
        {
            string publicroom = "/_matrix/client/r0/publicRooms";
            string query = BASE_URL + publicroom + authstring;

            Debug.WriteLine(query);
            var response = await client.GetAsync(query);
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);
            Debug.WriteLine(mes);

            dynamic values = JsonConvert.DeserializeObject<dynamic>(mes);
            return values;
        }

        public async Task<dynamic> purge(string roomid)
        {
            int size = 0 ;
            int count = 0;
            string[] members;

            //GET THE MEMBERS INTO AN ARRAY
            string memberquery = "/_matrix/client/r0/rooms/"+roomid+"/members";
            string joinroom = "/_matrix/client/r0/rooms/{roomId}/join";
            string kickquery = "/_matrix/client/r0/rooms/"+roomid+"/kick";
            string setprivate = "/_matrix/client/r0/rooms/"+roomid+ "/state/m.room.join_rules";
            string delist = "/_matrix/client/r0/directory/list/room/"+roomid;

            string query = BASE_URL + memberquery + authstring;
            string joinroomm = BASE_URL + joinroom + authstring;
            string kickqueryy = BASE_URL + kickquery + authstring;
            string setprivatee = BASE_URL + setprivate + authstring;
            string delistt = BASE_URL + delist + authstring;

            string joinjson = "{\"room_id\": \""+roomid+"\"}";
            await client.PostAsync(kickqueryy, new StringContent(joinjson, Encoding.UTF8, "application/json"));

            Debug.WriteLine(query);
            var response = await client.GetAsync(query);
            var mes = await response.Content.ReadAsStringAsync();
            checkresp(response.StatusCode);

            Debug.WriteLine(mes);

            dynamic values = JsonConvert.DeserializeObject<dynamic>(mes);

            foreach (dynamic x in values.chunk)
            {
                size++;
            }

            Debug.WriteLine(size);
            members = new string[size];
            count = 0;

            foreach (dynamic x in values.chunk)
            {
                members[count] = values.chunk[count].user_id;
                Debug.WriteLine(members[count]);
                count++;
            }

            //Delist room and lockdown

            string json3 = "{\"visibility\": \"private\"}";
            await client.PutAsync(delistt, new StringContent(json3, Encoding.UTF8, "application/json"));

            string json2 = "{\"join_rule\": \"invite\"}";
            await client.PutAsync(setprivatee, new StringContent(json2, Encoding.UTF8, "application/json"));

            //Proceeds to kick all members
            foreach (string x in members)
            {
                if (x != adminuser)
                {
                    Debug.WriteLine("KICKED: " + x);
                    string json = "{\"reason\": \"This room has been purged\", \"user_id\": \"" + x + "\"}";
                    await client.PostAsync(kickqueryy, new StringContent(json, Encoding.UTF8, "application/json"));
                }
            }
            Debug.WriteLine("KICKED: " + adminuser);
            string jsona = "{\"reason\": \"This room has been purged\", \"user_id\": \"" + adminuser + "\"}";
            await client.PostAsync(kickqueryy, new StringContent(jsona, Encoding.UTF8, "application/json"));

            return null;
        }
    }
}
