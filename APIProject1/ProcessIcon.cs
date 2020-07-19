using System;
using System.Diagnostics;
using System.Windows.Forms;
using PiholeTaskbarManager.Properties;
namespace PiholeTaskbarManager
{
    class ProcessIcon : IDisposable
    {
        // <summary>
        // The NotifyIcon object
        // </summary>
        public static NotifyIcon ni;

        public static ConfigBox config_box = new ConfigBox();
        
        // Initializes a new instance of the <see cref="ProcessIcon"/> class.
        public ProcessIcon()
        {
            config_box.ConfigBox_Settings();
            //Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
            
    }
        //dispalys the icon in the system tray.
        public void Display()
        {
            //puts the icon in the system tray and allow it to react to mouse clicks
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.ICOPiHole;
            ni.Text = "Manage Pi-hole from the Taskbar!";
            ni.Visible = true;

            //Attach a context menu.
            ni.ContextMenuStrip = new ContextMenus().Create();
        }
        //releases unmanaged and optionally managed resources
        public void Dispose()
        {
            //when the application closes, this will remove the icon from the system tray immediately
            ni.Dispose();
        }
        //handles the MouseClick event of the ni control.
        private async void ni_MouseClick(object sender, MouseEventArgs e)
        {
            //handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                //start pihole admin page
                Process.Start("https://pi-hole.net");
            }

        }
    }
}