using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ;



        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string link = "https://www.youtube.com/watch?v=7Ac76qgeoA0&";
            string dsds = HttpGet(@"http:\\safeshare.tv/api/generate?url=" + link);
            dsds = dsds.Replace("\"", "").Replace("\\", "").Replace("{", "").Replace(":", "").Replace("statussuccess,messageSafeview was created!,data[safeshare_id", "");
            string[] gdf = dsds.Split(',');
            string newlink = "http://safeshare.tv/v/" + gdf[0];
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(newlink);


        }

        protected string get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                Console.WriteLine(rt);

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string HttpGet(string URI)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
    }
}
