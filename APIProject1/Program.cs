using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiholeTaskbarManager
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (ProcessIcon pi = new ProcessIcon())
            {
                pi.Display();

                APIHelper.InitializeAPI();
                APIHelper.StartTimer();
                Application.Run();                
            }
            
            
        }

    }
}
