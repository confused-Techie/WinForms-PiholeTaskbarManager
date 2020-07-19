using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiholeTaskbarManager
{
    public partial class ConfigBox : Form
    {
        public ConfigBox()
        {
            InitializeComponent();

            if (!APIHelper.useURL)
            {
                this.connectionCheckBox.Enabled = false;
            }

            testConnection.Click += TestConnection_Click;
            updateTime.TextChanged += UpdateTime_TextChanged;
            url.TextChanged += Url_Change;
            connectionCheckBox.CheckedChanged += ConnectionCheckBox_CheckedChanged;
            
        }

        private void ConnectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.connectionCheckBox.CheckState == CheckState.Unchecked)
            {
                APIHelper.useURL = false;
                this.connectionCheckBox.Enabled = false;
                this.testConnection.Checked = false;
            }
        }

        public void ConfigBox_Settings()
        {
            //_Load will hanlde assigning all saved values
            //first is the API Items that are checked
            //System.Diagnostics.Debug.WriteLine("ConfigBox_Load has been entered.");
            if (!string.IsNullOrEmpty(Properties.Settings.Default.APIITEMS))
            {
                //System.Diagnostics.Debug.WriteLine("APIItems have been detected, and should begin writing.");
                Properties.Settings.Default.APIITEMS.Split(',').ToList().ForEach(item =>
                {
                    var index = this.checkedList.Items.IndexOf(item);
                    this.checkedList.SetItemChecked(index, true);
                });
            }
            //next will be the Pi-hole URL
            if (!string.IsNullOrEmpty(Properties.Settings.Default.PIHOLEURL))
            {
                this.url.Text = Properties.Settings.Default.PIHOLEURL;
            }
            //then update time
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UPDATETIME))
            {
                this.updateTime.Text = Properties.Settings.Default.UPDATETIME;
            }
            //active status of use connection
            if (Properties.Settings.Default.CONNECTIONSTATUS == true)
            {
                this.connectionCheckBox.Checked = Properties.Settings.Default.CONNECTIONSTATUS;
            }
            //enabled status of use connection
            if (Properties.Settings.Default.CONNECTIONACTIVE == true)
            {
                this.connectionCheckBox.Enabled = Properties.Settings.Default.CONNECTIONACTIVE;
            }
        }

        private void UpdateTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Int32.Parse(updateTime.Text);
                Console.WriteLine("Parsed Update Time: " + updateTime.Text);
                APIHelper.updateTiming = Int32.Parse(updateTime.Text);
                //MessageBox.Show("Please relaunch program for Update Time to take effect. Would you like to relaunch now?", "API Timing Update");
                
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Please enter a valid time.");
            }
        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("URI Called from CheckBox");
            APIHelper.URICheck();
        }

        private void Url_Change(object sender, EventArgs e)
        {
            this.connectionCheckBox.Checked = false;
            APIHelper.useURL = false;
            this.connectionCheckBox.Enabled = false;
            this.testConnection.Checked = false;
        }
        

        
    }
}
