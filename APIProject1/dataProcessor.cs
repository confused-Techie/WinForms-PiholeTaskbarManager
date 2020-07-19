using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PiholeTaskbarManager
{
    public class dataProcessor
    {

        
        public static async Task<dataModel> LoadPihole()
        {
            
            string url = ProcessIcon.config_box.url.Text;
            if (APIHelper.useURL)
            {

                using (HttpResponseMessage result = await APIHelper.APIClient.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode && result.Headers.ToString().Contains("X-Pi-hole:"))
                    {
                        dataModel apiResult = await result.Content.ReadAsAsync<dataModel>();
                        
                        //this needs to be able to find X-Pi-hole value, and added to the if
                        return apiResult;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Make sure that the adress for piHole is correct.");
                        APIHelper.useURL = false;
                        ProcessIcon.config_box.connectionCheckBox.Checked = false;
                        return null;
                        //throw new Exception(result.ReasonPhrase);
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
