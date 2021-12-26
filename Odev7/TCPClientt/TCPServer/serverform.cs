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

namespace TCPServer
{
    public partial class serverform : Form
    {
        public serverform()
        {
            InitializeComponent();
        }

        //bağlantı(başarılı - başarısız) ve veri olaylarını destekler
        SimpleTcpServer server;
        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start(); // TCP sunucusu başlatılıyor
            textInfo.Text += $"Starting...{Environment.NewLine}";
            btnSend.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            server = new SimpleTcpServer(textIp.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object sender, DataReceivedFromClientEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { 
                textInfo.Text += $"{e.IpPort}: {aes.Decryption(Encoding.UTF8.GetString(e.Data))}{Environment.NewLine}";
          });
             }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { 
            textInfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
            // başarılı bağlantılarda ıp adresi listeden kaldırılacak
            lstClientIP.Items.Remove(e.IpPort);});
           
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {textInfo.Text += $"{e.IpPort} connected.{Environment.NewLine}";
            // başarılı bağlantılarda ıp adresi listeye eklenecek
            lstClientIP.Items.Add(e.IpPort);
            });
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text) && lstClientIP.SelectedItem != null) // mesajı kontrol et, listeden istemci ipsi seç 
                {
                    server.Send(lstClientIP.SelectedItem.ToString(), aes.Encryption(txtMessage.Text));
                    textInfo.Text += $"Server: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;

                }
            }
        }
    }
}
