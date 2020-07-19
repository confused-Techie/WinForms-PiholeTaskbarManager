using System;
using System.Diagnostics;
using System.Windows.Forms;
using PiholeTaskbarManager.Properties;
using System.Drawing;
using Newtonsoft.Json;
using System.Linq;

namespace PiholeTaskbarManager
{
    class ContextMenus
    {
        
        bool isConfigLoaded = false;

        
        public static ToolStripMenuItem domains_blocked;
        public static ToolStripMenuItem dns_queries;
        public static ToolStripMenuItem ads_blocked;
        public static ToolStripMenuItem ads_percent;
        public static ToolStripMenuItem unique_domain; 
        public static ToolStripMenuItem queries_forwarded;
        public static ToolStripMenuItem queries_cached;
        public static ToolStripMenuItem clients_ever;
        public static ToolStripMenuItem unique_clients;
        public static ToolStripMenuItem dns_queries_all;
        public static ToolStripMenuItem nodata;
        public static ToolStripMenuItem nxdomain;
        public static ToolStripMenuItem cname;
        public static ToolStripMenuItem ip;
        public static ToolStripMenuItem privacy;
        public static ToolStripMenuItem status;
        //public static ToolStripMenuItem gravity_updated;
        //public static ToolStripMenuItem gravity_exists;
        //public static ToolStripMenuItem absolute;
        //public static ToolStripMenuItem relative;
        //public static ToolStripMenuItem days;
        //public static ToolStripMenuItem hours;
        //public static ToolStripMenuItem minutes;

        //creates this instance
        public ContextMenuStrip Create()
        {
            //add the default menu options
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            ////////////////STATS

          
            domains_blocked = new ToolStripMenuItem();
            domains_blocked.Text = $"Domains Blocked: LOADING";
            domains_blocked.Available = false;
            menu.Items.Add(domains_blocked);
            
            
            //assigning the item a public static ToolStripMenuItem is essential to be able to update the text
            
            //domain queries
            dns_queries = new ToolStripMenuItem();
            dns_queries.Text = $"Domain Queries: LOADING";
            dns_queries.Available = false;
            menu.Items.Add(dns_queries);

            ads_blocked = new ToolStripMenuItem();
            ads_blocked.Text = $"Ads Blocked: LOADING";
            ads_blocked.Available = false;
            menu.Items.Add(ads_blocked);

            ads_percent = new ToolStripMenuItem();
            ads_percent.Text = $"Percent Ads Blocked: LOADING";
            ads_percent.Available = false;
            menu.Items.Add(ads_percent);

            unique_domain = new ToolStripMenuItem();
            unique_domain.Text = $"Unique Domains: LOADING";
            unique_domain.Available = false;
            menu.Items.Add(unique_domain);

            queries_forwarded = new ToolStripMenuItem();
            queries_forwarded.Text = $"Queries Forwarded: LOADING";
            queries_forwarded.Available = false;
            menu.Items.Add(queries_forwarded);

            queries_cached = new ToolStripMenuItem();
            queries_cached.Text = $"Quereies Cached: LOADING";
            queries_cached.Available = false;
            menu.Items.Add(queries_cached);

            clients_ever = new ToolStripMenuItem();
            clients_ever.Text = $"Clients Ever Seen: LOADING";
            clients_ever.Available = false;
            menu.Items.Add(clients_ever);

            unique_clients = new ToolStripMenuItem();
            unique_clients.Text = $"Unique Clients: LOADING";
            unique_clients.Available = false;
            menu.Items.Add(unique_clients);

            dns_queries_all = new ToolStripMenuItem();
            dns_queries_all.Text = $"DNS Queries ALL Types: LOADING";
            dns_queries_all.Available = false;
            menu.Items.Add(dns_queries_all);

            nodata = new ToolStripMenuItem();
            nodata.Text = $"NODATA Reply: LOADING";
            nodata.Available = false;
            menu.Items.Add(nodata);

            nxdomain = new ToolStripMenuItem();
            nxdomain.Text = $"NXDOMAIN Reply: LOADING";
            //nxdomain.Enabled = false; //this only greys out the item
            nxdomain.Available = false; //this actually turns it on and off
            menu.Items.Add(nxdomain);

            
            cname = new ToolStripMenuItem();
            cname.Text = $" {APIHelper.api_texts[12] } LOADING";
            cname.Available = false;
            menu.Items.Add(cname);

            ip = new ToolStripMenuItem();
            ip.Text = $" {APIHelper.api_texts[13] } LOADING";
            ip.Available = false;
            menu.Items.Add(ip);

            privacy = new ToolStripMenuItem();
            privacy.Text = $" {APIHelper.api_texts[14] } LOADING";
            privacy.Available = false;
            menu.Items.Add(privacy);

            status = new ToolStripMenuItem();
            status.Text = $" {APIHelper.api_texts[15] } LOADING";
            status.Available = false;
            menu.Items.Add(status);

            //////////////MENU ITEMS

            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            //Configure piHole
            item = new ToolStripMenuItem();
            item.Text = "Configure";
            item.Click += new EventHandler(Configure_Click);
            //item.Image = Resources.Explorer;
            menu.Items.Add(item);

            //separator
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            //exit
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.pngPiHole;
            menu.Items.Add(item);

            return menu;
        }

        void Configure_Click(object sender, EventArgs e)
        {
            if (!isConfigLoaded)
            {
                isConfigLoaded = true;
                ProcessIcon.config_box.ShowDialog();
                isConfigLoaded = false;
            }
        }

        public void Exit_Click(object sender, EventArgs e)
        {
            //saving user data will be handled here
            Properties.Settings.Default.PIHOLEURL = ProcessIcon.config_box.url.Text;
            Properties.Settings.Default.CONNECTIONSTATUS = ProcessIcon.config_box.connectionCheckBox.Checked;
            Properties.Settings.Default.CONNECTIONACTIVE = ProcessIcon.config_box.connectionCheckBox.Enabled;
            Properties.Settings.Default.UPDATETIME = ProcessIcon.config_box.updateTime.Text;
            Properties.Settings.Default.GOODURL = APIHelper.useURL;

            //while a bit janky, seems the only way to save the list of checked Items.
            var indices = ProcessIcon.config_box.checkedList.CheckedItems.Cast<string>().ToArray();
            Properties.Settings.Default.APIITEMS = string.Join(",", indices);

            //this saves all the settings
            Properties.Settings.Default.Save();
            Console.WriteLine("All Settings saved.");
            //System.Diagnostics.Debug.WriteLine("Settings have been saved.");
            //close the program
            Application.Exit();
        }

    }
}