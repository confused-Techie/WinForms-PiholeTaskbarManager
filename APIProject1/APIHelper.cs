using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiholeTaskbarManager
{
    public class APIHelper
    {

        public static string[] api_texts = new string[] {
            "Domains Blocked: ",
            "Domain Queries: ",
            "Ads Blocked: ",
            "Percent Ads Blocked: ",
            "Unique Domains: ",
            "Queries Forwarded: ",
            "Queries Cached: ",
            "Clients Ever Seen: ",
            "Unique Clients: ",
            "DNS Queries All Types: ",
            "NODATA Replies: ",
            "NXDOMAIN Replies: ",
            "CNAME Replies: ",
            "IP Replies: ",
            "Resolver Privacy Level: ",
            "Current Status: "
        };

        public static string piURL;
        public static bool useURL = false;
        public static int updateTiming; 
        public static HttpClient APIClient { get; set; }

        public static void InitializeAPI()
        {
            useURL = Properties.Settings.Default.GOODURL;
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void StartTimer()
        {
            updateTiming = Int32.Parse(ProcessIcon.config_box.updateTime.Text);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (updateTiming * 1000); //10 sec default
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private static async void timer_Tick(object sender, EventArgs e)
        {
            if (ProcessIcon.config_box.connectionCheckBox.CheckState == CheckState.Checked && useURL)
            {
                Console.WriteLine("Updating API");
                
                var piInfo = await dataProcessor.LoadPihole();


                if (piInfo != null)
                {
                    
                    //This foreach first starts the loop through each item of the checkbox.
                    //Then checks if the item is checked, and is equal to one of the options, wich if it is, will then call the API, 
                    //then if the same item is not checked, will disable it
                    foreach (object itemChecked in ProcessIcon.config_box.checkedList.Items)
                    {

                        //this will assign a checkItem
                        CheckState check_state = ProcessIcon.config_box.checkedList.GetItemCheckState(ProcessIcon.config_box.checkedList.Items.IndexOf(itemChecked));
                        //this will assign Index value string
                        string check_string_index = ProcessIcon.config_box.checkedList.Items.IndexOf(itemChecked).ToString();
                        //CONTEXTMENU        API-DATAMODEL
                        //DOMAINS_BLOCKED && domains_being_blocked
                        if (check_state == CheckState.Checked && check_string_index == "0")
                        {
                            ContextMenus.domains_blocked.Available = true;
                            ContextMenus.domains_blocked.Text = api_texts[0] + piInfo.ads_blocked_today.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "0")
                        {
                            //this handles unchecked, and indetermine
                            ContextMenus.domains_blocked.Available = false;
                        }
                        //DNS_QUERIES && dns_queries_today
                        else if (check_state == CheckState.Checked && check_string_index == "1")
                        {
                            ContextMenus.dns_queries.Available = true;
                            ContextMenus.dns_queries.Text = api_texts[1] + piInfo.dns_queries_today.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "1")
                        {
                            ContextMenus.dns_queries.Available = false;
                        }
                        //ADS_BLOCKED && ads_blocked_today
                        else if (check_state == CheckState.Checked && check_string_index == "2")
                        {
                            ContextMenus.ads_blocked.Available = true;
                            ContextMenus.ads_blocked.Text = api_texts[2] + piInfo.ads_blocked_today.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "2")
                        {
                            ContextMenus.ads_blocked.Available = false;
                        }
                        //ADS_PERCENT && ads_percentage_today
                        else if (check_state == CheckState.Checked && check_string_index == "3")
                        {
                            ContextMenus.ads_percent.Available = true;
                            ContextMenus.ads_percent.Text = api_texts[3] + piInfo.ads_percentage_today.ToString() + "%";
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "3")
                        {
                            ContextMenus.ads_percent.Available = false;
                        }
                        //UNIQUE_DOMAINS && unique_domains
                        else if (check_state == CheckState.Checked && check_string_index == "4")
                        {
                            ContextMenus.unique_domain.Available = true;
                            ContextMenus.unique_domain.Text = api_texts[4] + piInfo.unique_domains.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "4")
                        {
                            ContextMenus.unique_domain.Available = false;
                        }
                        //QUERIES_FORWARDED && queries_forwarded
                        else if (check_state == CheckState.Checked && check_string_index == "5")
                        {
                            ContextMenus.queries_forwarded.Available = true;
                            ContextMenus.queries_forwarded.Text = api_texts[5] + piInfo.queries_forwarded.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "5")
                        {
                            ContextMenus.queries_forwarded.Available = false;
                        }
                        //QUERIES_CACHED && queries_cached
                        else if (check_state == CheckState.Checked && check_string_index == "6")
                        {
                            ContextMenus.queries_cached.Available = true;
                            ContextMenus.queries_cached.Text = api_texts[6] + piInfo.queries_cached.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "6")
                        {
                            ContextMenus.queries_cached.Available = false;
                        }
                        //CLIENTS_EVER && clients_ever_seen
                        else if (check_state == CheckState.Checked && check_string_index == "7")
                        {
                            ContextMenus.clients_ever.Available = true;
                            ContextMenus.clients_ever.Text = api_texts[7] + piInfo.clients_ever_seen.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "7")
                        {
                            ContextMenus.clients_ever.Available = false;
                        }
                        //UNIQUE_CLIENTS && unique_clients
                        else if (check_state == CheckState.Checked && check_string_index == "8")
                        {
                            ContextMenus.unique_clients.Available = true;
                            ContextMenus.unique_clients.Text = api_texts[8] + piInfo.unique_clients.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "8")
                        {
                            ContextMenus.unique_clients.Available = false;
                        }
                        //DNS_QUERIES_ALL && dns_queries_all_types
                        else if (check_state == CheckState.Checked && check_string_index == "9")
                        {
                            ContextMenus.dns_queries_all.Available = true;
                            ContextMenus.dns_queries_all.Text = api_texts[9] + piInfo.dns_queries_all_types.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "9")
                        {
                            ContextMenus.dns_queries_all.Available = false;
                        }
                        //NODATA && reply_NODATA
                        else if (check_state == CheckState.Checked && check_string_index == "10")
                        {
                            ContextMenus.nodata.Available = true;
                            ContextMenus.nodata.Text = api_texts[10] + piInfo.reply_NODATA.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "10")
                        {
                            ContextMenus.nodata.Available = false;
                        }
                        //NXDOMAIN && reply_NXDOMAIN
                        else if (check_state == CheckState.Checked && check_string_index == "11")
                        {
                            ContextMenus.nxdomain.Available = true;
                            ContextMenus.nxdomain.Text = api_texts[11] + piInfo.reply_NXDOMAIN.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "11")
                        {
                            ContextMenus.nxdomain.Available = false;
                        }
                        //CNAME && reply_CNAME
                        else if (check_state == CheckState.Checked && check_string_index == "12")
                        {
                            ContextMenus.cname.Available = true;
                            ContextMenus.cname.Text = api_texts[12] + piInfo.reply_CNAME.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "12")
                        {
                            ContextMenus.cname.Available = false;
                        }
                        //ip && reply_IP
                        else if (check_state == CheckState.Checked && check_string_index == "13")
                        {
                            ContextMenus.ip.Available = true;
                            ContextMenus.ip.Text = api_texts[13] + piInfo.reply_IP.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "13")
                        {
                            ContextMenus.ip.Available = false;
                        }
                        //privacy && privacy_level
                        else if (check_state == CheckState.Checked && check_string_index == "14")
                        {
                            ContextMenus.privacy.Available = true;
                            ContextMenus.privacy.Text = api_texts[14] + piInfo.privacy_level.ToString();
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "14")
                        {
                            ContextMenus.privacy.Available = false;
                        }
                        //status && status
                        else if (check_state == CheckState.Checked && check_string_index == "15")
                        {
                            ContextMenus.status.Available = true;
                            ContextMenus.status.Text = api_texts[15] + piInfo.status;   //this is already a string
                        }
                        else if (check_state != CheckState.Checked && check_string_index == "15")
                        {
                            ContextMenus.status.Available = false;
                        }

                    }
                } else
                {
                    System.Windows.Forms.MessageBox.Show("Make sure that the adress for piHole is correct.");
                    useURL = false;
                    ProcessIcon.config_box.connectionCheckBox.Checked = false;
                }
            }
        }

        public static async void URICheck()
        {

            ////////For now it may be easier to just tell the user if its wrong rather than fix it automatically
           
            
            if (ProcessIcon.config_box.testConnection.CheckState == CheckState.Checked)
            {
                Console.WriteLine("URI Check has begun.");
                
                if (!ProcessIcon.config_box.url.Text.Contains("http://")
                    || !ProcessIcon.config_box.url.Text.Contains("admin") 
                    || !ProcessIcon.config_box.url.Text.Contains("api.php"))
                {
                    
                    System.Windows.Forms.MessageBox.Show("Make sure your URL contains 'http://' or 'https://', and ends with '/admin/api.php'");
                    
                    Console.WriteLine("URI Check has failed.");
                } else
                {
                    Console.WriteLine("URI Check has succedded");

                    //test the connection
                    
                    useURL = true;
                    ProcessIcon.config_box.connectionCheckBox.Enabled = true;
                }
            }
        }

    }
}
