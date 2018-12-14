using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ok = @"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR6,6~SD15^JUS^LRN^CI0^XZ
^XA
^MMT
^PW1200
^LL0600
^LS0
^FT212,342^A0N,228,494^FH\^FDOK^FS
^PQ1,0,1,Y^XZ";
        public string nok = @"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR6,6~SD15^JUS^LRN^CI0^XZ
^XA
^MMT
^PW1200
^LL0600
^LS0
^FT108,360^A0N,228,494^FH\^FDNOK^FS
^PQ1,0,1,Y^XZ
";
        public void SendData(string zpl)
        {
            NetworkStream ns = null;
            Socket socket = null;
            IPEndPoint printerIP = null;
            String IP = textBox5.Text;
            try
            {
                if (printerIP == null)
                {
                    /* IP is a string property for the printer's IP address. */
                    /* 6101 is the common port of all our Zebra printers. */
                    printerIP = new IPEndPoint(IPAddress.Parse(IP), 9100);
                }

                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                socket.Connect(printerIP);

                ns = new NetworkStream(socket);

                byte[] toSend = Encoding.ASCII.GetBytes(zpl);
                ns.Write(toSend, 0, toSend.Length);
            }
            finally
            {
                if (ns != null)
                    ns.Close();

                if (socket != null && socket.Connected)
                    socket.Close();
            }
        }
        public void intia()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label9.Text = "item3";
            label7.Text = "item2";
            label5.Text = "item1";
            label8.Text = "item4";
            label10.Text = "Lot1";
            label11.Text = "Lot2";
            label12.Text = "Lot3";
            label13.Text = "Lot4";
            label14.Text = "Qunatity 1";
            label15.Text = "Qunatity 2";
            label16.Text = "Qunatity 3";
            label17.Text = "Qunatity 4";


        }
        private void label4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.100.155\\ERPLN; Initial Catalog = erplnfp9db; User ID = sa; Password = P@ssw0rd123");
            con.Open();
            string sql = @"select t_item,t_clot,t_qhds from twhwmd530502 where t_huid='" + textBox1.Text + "';";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label5.Text = reader.GetString(0);
                label10.Text = reader.GetString(1);
                label14.Text = reader.GetDouble(2).ToString();


            }


            con.Close();
            
        }
        private void label5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.100.155\\ERPLN; Initial Catalog = erplnfp9db; User ID = sa; Password = P@ssw0rd123");
            con.Open();
            string sql = @"select t_item,t_clot,t_qhds from twhwmd530502 where t_huid='" + textBox2.Text + "';";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label7.Text = reader.GetString(0);
                label11.Text = reader.GetString(1);
                label15.Text = reader.GetDouble(2).ToString();


            }


            con.Close();

        }
        private void label6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.100.155\\ERPLN; Initial Catalog = erplnfp9db; User ID = sa; Password = P@ssw0rd123");
            con.Open();
            string sql = @"select t_item,t_clot,t_qhds from twhwmd530502 where t_huid='" + textBox3.Text + "';";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label9.Text = reader.GetString(0);
                label12.Text = reader.GetString(1);
                label16.Text = reader.GetDouble(2).ToString();


            }


            con.Close();

        }
        private void label7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.100.155\\ERPLN; Initial Catalog = erplnfp9db; User ID = sa; Password = P@ssw0rd123");
            con.Open();
            string sql = @"select t_item,t_clot,t_qhds from twhwmd530502 where t_huid='" + textBox4.Text + "';";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label8.Text = reader.GetString(0);
                label13.Text = reader.GetString(1);
                label17.Text = reader.GetDouble(2).ToString();
            }


            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((label8.Text== label9.Text) & (label8.Text == label7.Text) &(label8.Text == label5.Text))
                { MessageBox.Show("OK");
                this.SendData(ok);
                }
            else if ((label9.Text=="item3") & (label8.Text == label7.Text) & (label8.Text == label5.Text))
            { MessageBox.Show("OK");
                this.SendData(ok);
            }
            else if ((label9.Text == "item3") & ( label7.Text=="item2") & (label8.Text == label5.Text))
            { MessageBox.Show("OK");
                this.SendData(ok);
            }
            else
            { MessageBox.Show("NOK");
                this.SendData(nok);
            }
            
            
            this.intia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.100.163; Initial Catalog = Rewinding_Data; User ID = sa; Password = 1234");
            con.Open();
            MessageBox.Show("conection ok");

            string sql = @"INSERT INTO dbo.Rew_output (Huidout,itemout,qtyout,huidin1,qtyin1,huidin2,qtyin2,huidin3,qtyin3,dtime) VALUES (" + textBox4.Text + "," + label8.Text + "," + label17.Text + "," + textBox1.Text + "," + label14.Text + "," + textBox2.Text + "," + label15.Text + "," + textBox3.Text + "," + label16.Text + ",GETDATE());";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();


            con.Close();
        }
    }
}
