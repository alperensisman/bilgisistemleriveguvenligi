using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClientt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new(textIp.Text);
                client.Events.Connected += Events_Connected;
                client.Events.Disconnected += Events_Disconnected;
                client.Events.DataReceived += Events_DataReceived;
                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    client.Send(aes.Encryption(txtMessage.Text));
                    textInfo.Text += $"Me: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { 
                textInfo.Text += $"Server: {aes.Decryption(Encoding.UTF8.GetString(e.Data))}{Environment.NewLine}";
         });
               }

        private void Events_Disconnected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                textInfo.Text += $"Server disconnected.{Environment.NewLine}";
        });
            }

        private void Events_Connected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                textInfo.Text += $"Server connected.{Environment.NewLine}";
         });    
        }
    }
}
