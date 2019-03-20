using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtSubject.Text = string.Empty;
        txtMessage.Value = string.Empty;

    }

    protected void Send_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("estera9704@gmail.comk"));
        msg.From = new MailAddress(txtEmail.Text);
        msg.Subject = txtSubject.Text;
        msg.Body = txtName.Text + Environment.NewLine + txtMessage.Value;
        SmtpClient client = new SmtpClient();
        client.Host = "localhost";//Place your smtp server in quotation marks (i.e. “smtp.live.com”)
        client.Port = 25;
        client.Credentials = new NetworkCredential();
        client.EnableSsl = true;
        client.Send(msg);
    }
}