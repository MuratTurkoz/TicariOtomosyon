using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomosyon_Uygulama
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("trkz.murat@gmail.com", "causy1453");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mailMessage.To.Add(txtMail.Text);
            mailMessage.From = new MailAddress("trkz.murat@gmail.com");
            mailMessage.Subject = txtKonu.Text;
            mailMessage.Body = rchBoxMesaj.Text;
            istemci.Send(mailMessage);

        }
    }
}
