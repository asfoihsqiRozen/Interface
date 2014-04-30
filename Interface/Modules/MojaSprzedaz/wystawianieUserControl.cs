//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Interface.Komentarze;
using System.IO;


using Interface.webapi; 
using kodMacka;

namespace Interface.MojaSprzedaz
{
    public partial class wystawianieUserControl : UserControl
    {
        const string webAPIKey = "7dda4ce4";
        AllegroWebApiService allegroService = new AllegroWebApiService();
      //  public static CatInfoType[] catsData;
       // public static Categories cat;


        public wystawianieUserControl()
        {
            InitializeComponent();


                
              //  cat = new Categories(allegroService, webAPIKey, out verKey, out verString);
              //  catsData = allegroService.doGetCatsData(1, 0, webAPIKey, out verKey, out verString);
               

            ArrayList tempCats = new ArrayList();

            for (int i = 0; i < loginForm.catsData.Length; i++)
            {
                if (loginForm.catsData[i].catparent == 0)
                {
                    tempCats.Add(loginForm.catsData[i].catname);
                }
            }
            var tempCatsArray = tempCats.ToArray();
            this.comboBox1.Items.AddRange(tempCatsArray);
            SaveFileDialog Filename =  new SaveFileDialog();
            string curDir = Directory.GetCurrentDirectory();
                
               // this.webBrowser1.Url = new Uri(String.Format("file:///{0}/demos/index.html",curDir ));
               // webBrowser1.Controls[webBrowser1.Controls.IndexOfKey()].Dock = DockStyle.Fill;
               // webBrowser1.Refresh();
           }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string[] childrenCatNames = loginForm.cat.getChildrenNames(loginForm.cat.getCatId(comboBox1.Text));
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(childrenCatNames);
            comboBox2.Visible = true;
            //
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] childrenCatNames = loginForm.cat.getChildrenNames(loginForm.cat.getCatId(comboBox2.Text));
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(childrenCatNames);
            comboBox3.Visible = true;

        }

       


      }
}
