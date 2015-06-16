using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {



        private void pingSender()
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            // Use the default Ttl value which is 128, 
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted. 
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            try
            {





                string[] words = textBox1.Text.Split(',');
                int i;
                for (i = 0; i < words.GetLength(0); i++)
                {
                    words[i] = words[i].Trim();

                    if (words[i].StartsWith("http://"))
                    {
                        words[i] = words[i].Replace("http://", "");
                    }

                    PingReply reply = pingSender.Send(words[i].Trim(), timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {

                        string[] arr = new string[4];
                        ListViewItem itm;

                        //Add first item
                        arr[0] = words[i].Trim();
                        arr[1] = reply.Status.ToString();
                        arr[2] = reply.RoundtripTime.ToString() + "ms";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                        itm.ForeColor = System.Drawing.Color.Green;

                        // MessageBox.Show("Complete."  +
                        /* Environment.NewLine +
                             "Ping recieved: " + reply.Address.ToString() +
                         Environment.NewLine +
                         "Size of data: " + reply.Buffer.Length.ToString() + "bytes" +
                         Environment.NewLine +
                         "How long the connection lasted: " + reply.Options.Ttl.ToString() + "ms" +
                         Environment.NewLine +
                         "Ping: " + reply.RoundtripTime.ToString(), "Success", MessageBoxButtons.OKCancel);*/


                    }
                    else
                    {
                        string[] arr = new string[4];
                        ListViewItem itm;
                        //Add first item
                        arr[0] = words[i].Trim();
                        arr[1] = reply.Status.ToString();
                        arr[2] = "N/A";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                        itm.ForeColor = System.Drawing.Color.Red;
                    }
                }


            }
            catch (Exception ex)
            {


                //type - name - value
                object sender = this;
                EventArgs e = new EventArgs();

                button2_Click(sender, e);
                MessageBox.Show("URL/IP Address not recognised; " + ex.Message, "Error!", MessageBoxButtons.OKCancel);


            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public int timeLeft { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            pingSender();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (timeLeft > 0)
            {

                int value = (int)numericUpDown1.Value;
                // Display the new time left 
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

                if (value == 0)
                {

                    object sender2 = this;
                    EventArgs e2 = new EventArgs();

                    button2_Click(sender2, e2);
                    MessageBox.Show("value Cannot Be 0", "Error!", MessageBoxButtons.OKCancel);
                }



            }

            else
            {

                int value = (int)numericUpDown1.Value;
                timeLeft = value;
                pingSender();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add column header
            listView1.Columns.Add("Ping recieved by:", 150);
            listView1.Columns.Add("Status:", 90);
            listView1.Columns.Add("Ping:", 65);
            listView1.MinimumSize = new System.Drawing.Size(300, 300);




            timeLeft = 0;
        }





        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty) return;
            timer1.Start(); textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); textBox1.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void timeLabel_Click_1(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Width = 270;
            listView1.FullRowSelect = true;


            //Add column header
            listView1.Columns.Add("ProductName", 100);
            listView1.Columns.Add("Price", 70);
            listView1.Columns.Add("Quantity", 70);

            //Add items in the listview


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.cambridgesoftware.co.uk");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.cambridgesoftware.co.uk");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
     Application.Exit();
} 
        }
    }






/*Add first item
arr[0] = "product_1";
arr[1] = "100";
arr[2] = "10";
itm = new ListViewItem(arr);
listView1.Items.Add(itm);

//Add second item
arr[0] = "product_2";
arr[1] = "200";
arr[2] = "20";
itm = new ListViewItem(arr);
listView1.Items.Add(itm);
}

private void button1_Click_2(object sender, EventArgs e)
{
string productName = null;
string price = null;
string quantity = null;
            
productName = listView1.SelectedItems[0].SubItems[0].Text;
price = listView1.SelectedItems[0].SubItems[1].Text;
quantity = listView1.SelectedItems[0].SubItems[2].Text;

MessageBox.Show(productName + " , " + price + " , " + quantity);
}

private void listView1_SelectedIndexChanged(object sender, EventArgs e)
{

}
}

}*/
    
    


  


