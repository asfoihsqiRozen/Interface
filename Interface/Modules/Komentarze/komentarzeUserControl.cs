using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Interface.Komentarze;

namespace Interface
{
    public partial class komentarzeUserControl : UserControl
    {
        public komentarzeUserControl()
        {
            InitializeComponent();

            daneDGV.Focus();
            //ladownie loga*******
            /*
            string url = "http://fc05.deviantart.net/fs71/f/2013/292/6/d/smoke_weed_everyday_by_tinywin-d6r1ylo.png";
            WebRequest zadanie = WebRequest.Create(url);
            WebResponse odpowiedz = zadanie.GetResponse();
            Stream strumien = odpowiedz.GetResponseStream();
            Image logo=Image.FromStream(strumien);

            logoPB.Image = logo;
            Graphics g = Graphics.FromImage(logo);

            g.DrawImage(logoPB.Image, new Point(0, 0));
            
            logoPB.Refresh();
            */
            //********************
            //wstawianie danych do DGV==================================================////////
            for(int i=0;i<100;i++)
            {
                
                int RowIndex = daneDGV.Rows.Add();
                daneDGV.Rows[RowIndex].Cells[0].Value = "Nazwa Aukcji"+Convert.ToString(i);
                daneDGV.Rows[RowIndex].Cells[1].Value = "Adam" + Convert.ToString(i);
                daneDGV.Rows[RowIndex].Cells[2].Value = "Małysz" + Convert.ToString(i);
                daneDGV.Rows[RowIndex].Cells[3].Value = "Małysz" + Convert.ToString(i);
                daneDGV.Rows[RowIndex].Cells[4].Value = "Małysz" + Convert.ToString(i);
                daneDGV.Rows[RowIndex].Cells[5].Value = "Małysz" + Convert.ToString(i);
            }
            //=========================================================================////////



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void wystawBT_Click(object sender, EventArgs e)
        {
            blankContainerForm f = new blankContainerForm();
            wystawKomentarzControl c = new wystawKomentarzControl();
            
            c.parentControl = this;
            this.Enabled = false;

            f.Controls.Add(c);
            f.Show();
        }

        private void uzyjSzablonuBT_Click(object sender, EventArgs e)
        {
            blankContainerForm f = new blankContainerForm();
        //    managerKomentarzyControl c = new managerKomentarzyControl();

          //  c.parentControl = this;
           // this.Enabled = false;

          //  f.Controls.Add(c);
           // f.Show();
        }

        private void logoPB_Click(object sender, EventArgs e)
        {

        }
    }
}
